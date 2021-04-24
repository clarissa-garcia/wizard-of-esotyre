using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("World References")]
    public CharacterController controller;
    public Transform sceneGroundTrans;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    [Header("Movement Settings")]
    public float speed = 12f;
    public float runSpeed = 8f;
    public float jumpHeight = 1.0f; 
    public float gravity = -9.81f;

    private Vector3 velocity;
    private bool airborn = false;

    private MovementAudio movementAudio;
    private MovementAudio.MovementType movementType;
    private MovementAudio.TerrainType terrainStandingOn;

    private void Start()
    {
        terrainStandingOn = MovementAudio.TerrainType.NULL;
        movementAudio = GetComponent<MovementAudio>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (SceneManager.GetActiveScene().name == "Esotyre")
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

        if (other.gameObject.CompareTag("CastleEntrance"))
        {
            SceneManager.LoadSceneAsync("TowerInside");
        }
        else if (other.gameObject.CompareTag("InteriorDoor"))
        {
            SceneManager.LoadSceneAsync("Esotyre");
        }
        else
        {
            string tag = other.gameObject.tag;

            switch (tag)
            {
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
    }

    private void OnTriggerExit(Collider other)
    {
        terrainStandingOn = MovementAudio.TerrainType.NULL;
    }
}
