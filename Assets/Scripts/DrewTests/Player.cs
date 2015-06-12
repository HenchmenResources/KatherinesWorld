using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 12.0F;
    public float gravity = 20.0F;
    public CharacterController controller;
    public float pushPower = 0.5f;
    public bool isGrabbing = false;
    public int lives;

    private Vector3 moveDirection = Vector3.zero;
    private float vertSpeed;
    private Animator anim;
    private bool onPlatform = false;
    private GameObject platformObject;
    private bool objectGrabbed = false;
    private Rigidbody draggableObject;



    void Start()
    {
        anim = this.transform.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        lives = 5;
    }



    void Update()
    {
        KeepOnZAxis();
        Movement();
        Grabbing();
        if (lives < 0)
            GameOver();
    }


    //Fixed Update for physics updates. This is for use with platforms for the most part.
    void FixedUpdate()
    {
        KeepOnZAxis();

        // If the player is on a platform this frame access the platform through the stored platformObject (checking to make sure it's not null)
        if (onPlatform)
        {
            if (platformObject != null)
            {
                if (platformObject.gameObject.tag == "FreezeEffectHorizontal")
                {
                    if (platformObject.GetComponent<TwoPointMover>().outgoing == true)
                    {
                        Vector3 movement = new Vector3(platformObject.GetComponent<TwoPointMover>().bSpeed, 0, 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                    else
                    {
                        Vector3 movement = new Vector3(-platformObject.GetComponent<TwoPointMover>().bSpeed, 0, 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                }
                else if (platformObject.gameObject.tag == "FreezeEffectVertical")
                {
                    if (platformObject.GetComponent<TwoPointMover>().outgoing == true)
                    {
                        Vector3 movement = new Vector3(0, platformObject.GetComponent<TwoPointMover>().bSpeed, 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                    else
                    {
                        Vector3 movement = new Vector3(0, -platformObject.GetComponent<TwoPointMover>().bSpeed, 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                }
                else if (platformObject.gameObject.tag == "FreezeEffectDiagonalPos")
                {
                    if (platformObject.GetComponent<TwoPointMover>().outgoing == true)
                    {
                        Vector3 movement = new Vector3((platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Cos(platformObject.GetComponent<TwoPointMover>().bAngle)),
                                                        (platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Sin(platformObject.GetComponent<TwoPointMover>().bAngle)), 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                    else
                    {
                        Vector3 movement = new Vector3(-(platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Cos(platformObject.GetComponent<TwoPointMover>().bAngle)),
                                                        -(platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Sin(platformObject.GetComponent<TwoPointMover>().bAngle)), 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                }
                else if (platformObject.gameObject.tag == "FreezeEffectDiagonalNeg")
                {
                    if (platformObject.GetComponent<TwoPointMover>().outgoing == true)
                    {
                        Vector3 movement = new Vector3(-(platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Cos(platformObject.GetComponent<TwoPointMover>().bAngle)),
                                                        (platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Sin(platformObject.GetComponent<TwoPointMover>().bAngle)), 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                    else
                    {
                        Vector3 movement = new Vector3((platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Cos(platformObject.GetComponent<TwoPointMover>().bAngle)),
                                                        -(platformObject.GetComponent<TwoPointMover>().bSpeed * Mathf.Sin(platformObject.GetComponent<TwoPointMover>().bAngle)), 0);
                        Debug.Log(movement);
                        controller.Move(movement * Time.deltaTime);
                    }
                }
            }
        }
    }



    void Movement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
                vertSpeed = jumpSpeed;
        }
        moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection.y = vertSpeed;
        moveDirection.x *= speed;
        vertSpeed -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }



    void Grabbing()
    {
        if (Input.GetButton("Grab"))
            isGrabbing = true;
        else if (!Input.GetButton("Grab"))
            isGrabbing = false;
    }

    //Behavior for various objects with which the player collides.
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        // Check if the object we just collided with is a tagged as "moving"
        if (hit.gameObject.tag == "FreezeEffectHorizontal" || hit.gameObject.tag == "FreezeEffectVertical" || hit.gameObject.tag == "FreezeEffectDiagonalPos" || hit.gameObject.tag == "FreezeEffectDiagonalNeg")
        {

            // set our private variables to keep track of whether we're on the platform, and a reference to the platform we are on
            onPlatform = true;
            platformObject = hit.gameObject;

            // If we're not on a "moving" object we must be on the ground, set the onPlatform variable to false so we don't move 
        }
        else
        {
            onPlatform = false;
        }

        if ((hit.gameObject.tag == "DraggableLarge" || hit.gameObject.tag == "DraggableSmall") && isGrabbing == true)
        {
            objectGrabbed = true;
            draggableObject = hit.collider.attachedRigidbody;
            
            if (draggableObject == null || draggableObject.isKinematic)
                return;
            if (hit.moveDirection.y < -0.3)
                return;

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);
            draggableObject.velocity = pushDir * pushPower;
        }
        else
        {
            objectGrabbed = false;
        }
    }



    //Locks Z-Axis no matter what
    void KeepOnZAxis()
    {
        Vector3 axisKeep = transform.position;
        if(axisKeep.z != 0)
        {
            axisKeep.z = 0;
        }
        transform.position = axisKeep;
    }



    void GameOver()
    {
        Application.LoadLevel("GameOver");
    }
}