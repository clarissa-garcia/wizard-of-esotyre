using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 12f;
    public float runSpeed = 8f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 64f;

    /* Camera Vars*/
    private float xRotation = 0f;
    private GameObject FPCamera;
    private bool enabledCamMove; 

    /* Phsyical Movement Vars */
    private Vector3 velocity;
    private bool airborn = false;
    private CharacterController controller;
    
    /* Movement Audio */
    private MovementAudio movementAudio;
    private MovementAudio.MovementType movementType;
    private MovementAudio.TerrainType terrainStandingOn;
   
    private HUD playerHUD; 

    private void Start()
    {
        QuestManager.OnQuestChange += updateJump;
        playerHUD = GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>();

        /*-------Physical Movement Setup-----------*/
        terrainStandingOn = MovementAudio.TerrainType.NULL;
        movementAudio = GetComponent<MovementAudio>();
        controller = GetComponent<CharacterController>();

        /*-------Camera Movement Setup-------------*/
        FPCamera = GameObject.FindGameObjectWithTag("FPCamera");
        playerHUD.DisableCursor();
        enabledCamMove = true;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*------Camera Movement------*/
        if (enabledCamMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            FPCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.Rotate(Vector3.up * mouseX);
        }


        /*------Physical Movement------*/
        bool groundedPlayer = controller.isGrounded;
        float tempSpeed = speed;

        if (airborn)
        {
            if (groundedPlayer)
            {
                airborn = false;
                PlayMovementSound(MovementAudio.MovementType.JUMP_LAND);
            }
        }
        else
            movementType = MovementAudio.MovementType.WALKING;



        // ignore gravity during calculations
        if (groundedPlayer && velocity.y < 0)
            velocity.y = 0f;

        // Run movement mod
        if (groundedPlayer && Input.GetButton("Run"))
        {
            tempSpeed = runSpeed;
            movementType = MovementAudio.MovementType.RUNNING; 
        }
            

        // Normal Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * tempSpeed * Time.deltaTime);

        // Only do these while moving on x,z plane
        if (move != Vector3.zero && groundedPlayer)
                PlayMovementSound(movementType);

        // Jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            PlayMovementSound(MovementAudio.MovementType.JUMP_START);
            airborn = true; 
        }
            

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);            
    }

    /// <summary>
    /// Plays footstep sounds depending on what player is standing on
    /// </summary>
    private void PlayMovementSound(MovementAudio.MovementType type)
    {
        // Player is in Esotyre (Outside)
        if (SceneManager.GetActiveScene().name != "TowerInside")
        {
            // Player on object not terrain
            if (terrainStandingOn != MovementAudio.TerrainType.NULL)
            {
                movementAudio.Play(terrainStandingOn, movementType);
            }
            // Player on Terrain
            else
            {
                movementAudio.Play(movementType);
            }
        }
        // Player is inside, only sound is stone
        else
            movementAudio.Play(MovementAudio.TerrainType.STONE, movementType);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered triggered with:" + other);

        // Walking on object audio
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "RiverPlane":
                transform.position = new Vector3(-58.4f,20f,22.37f);
                break;
            case "Wood":
                terrainStandingOn = MovementAudio.TerrainType.WOOD;
                break; 
            case "Stone":
                terrainStandingOn = MovementAudio.TerrainType.STONE;
                break;
            default:
                terrainStandingOn = MovementAudio.TerrainType.NULL;
                break;
        }
    }

    private void updateJump(){
        if(QuestManager.Instance.quest == Quest.ENTER_CAVE){
            jumpHeight = 2.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        terrainStandingOn = MovementAudio.TerrainType.NULL;
    }

    private void OnDestroy() {
        QuestManager.OnQuestChange -= updateJump;
    }

    public void CameraMovement(bool b)
    {
        enabledCamMove = b; 
    }
}
