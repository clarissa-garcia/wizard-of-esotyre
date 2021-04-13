using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    

    public float speed = 12f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private bool isGrounded;

    private Footsteps footsteps;
    private GameObject standingOn; // object the player is on

    private void Start()
    {
        standingOn = null;  
        footsteps = GetComponent<Footsteps>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (move.magnitude != 0)
            {
                if (SceneManager.GetActiveScene().name == "Esotyre")
                {

                    if (standingOn)
                    {
                        footsteps.StepObject(standingOn.tag);
                    }
                    else
                    {
                        footsteps.StepTerrain();
                    }
                }
                else
                {
                    footsteps.StepObject("Stone");
                }
            }
        }
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
                case "Stone":
                    standingOn = other.gameObject;
                    break;
                default:
                    standingOn = null;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        standingOn = null; 
    }


}
