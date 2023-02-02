using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   [SerializeField] private CharacterController cc;

    private float speed = 9f;
    private float rotationSpeed = 720f;
    private float gravity = -9.81f;
    private float yVelocity = 0.0f;
    private float groundedYVelocity = -4f;

    private float jumpHeight = 1.5f;
    private float jumpTime = 0.5f;
    private float initialJumpVelocity;

    private float maxJumps = 2;
    private float jumpCount = 0;

    // Update is called once per frame

    private void Start()
    {
        float timeToApex = jumpTime / 2.0f;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    void Update()
    {

        float vIn = Input.GetAxis("Vertical");
        float hIn = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(hIn, 0, vIn);
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement = transform.TransformDirection(movement);
        movement *= speed;

        yVelocity += gravity * Time.deltaTime;
        if (cc.isGrounded && yVelocity < 0.0f)
        {
            yVelocity = groundedYVelocity;
            jumpCount = 0;
        }

        if(Input.GetButtonDown("Jump") && /*cc.isGrounded*/ jumpCount < maxJumps)
        {
            yVelocity = initialJumpVelocity;
            jumpCount++;
        }
        movement.y = yVelocity;


        movement *= Time.deltaTime;

        cc.Move(movement);




        Vector3 rotation = Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
        transform.Rotate(rotation);
    }

    public void Respawn(Vector3 spawnPoint)
    {
        // stop falling
        yVelocity = groundedYVelocity;
        // set the player to a given position
        transform.position = spawnPoint;
        // apply transform changes to the physics engine manually
        Physics.SyncTransforms();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Debug.Log("Yay");
        }
    }

    private void FixedUpdate()
    {
        
    }
}
