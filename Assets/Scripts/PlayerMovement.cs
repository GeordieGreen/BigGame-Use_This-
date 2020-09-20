using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    public int playerHitPoints = 100;
    [SerializeField] int playerDamage = 10;
    [SerializeField] int waterDamage = 100;
    [SerializeField] int healthUp = 5;
    [SerializeField] float speed = 5.0f;

    public float gravity = 9.81f;
    public float jumpForce = 30f;
    public float doubleJump = 0.5f;

    public Animator anim;
    public GameObject punchTrigger;

    public float coinCounter;
    float directionY;

    private bool isDoubleJump = false;

    public ParticleSystem dustTrail;

    [SerializeField]
    Transform cam;
    
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
      //Cursor.lockState = CursorLockMode.Locked;
        punchTrigger.SetActive(false);
        
        
    }

   
    void Update()
    {
        if (!Pause.isPaused)
        {
            float xMovement = Input.GetAxisRaw("Horizontal");

            float yMovement = Input.GetAxisRaw("Vertical");


            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("isWalking", true);
                
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("isWalking", true);
               
            }
            else if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("isWalking", true);
                
            }
            else if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("isWalking", true);
                
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
            if (!dustTrail.isPlaying && anim.GetBool("isWalking") == true)
            {
                dustTrail.Play();
                Debug.Log("Dust Trail");
            }
            else if (dustTrail.isPlaying && (anim.GetBool("isJumping") == true || anim.GetBool("isWalking") == false))
            {
                dustTrail.Stop();
                Debug.Log("NO Dust Trail");
            }
            

            Vector3 rightWorldMovement = cam.transform.right;
            Vector3 forwardWorldMovement = cam.transform.forward;
            forwardWorldMovement.y = 0;
            forwardWorldMovement.Normalize();


            Vector3 worldMoveInput = Vector3.ClampMagnitude(rightWorldMovement * xMovement + forwardWorldMovement * yMovement, 1);
            if (worldMoveInput != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(worldMoveInput);
            }

            if (controller.isGrounded)
            {
                
                isDoubleJump = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    directionY = jumpForce;
                    
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && isDoubleJump)
                {
                    directionY = jumpForce * doubleJump;
                    isDoubleJump = false;
                    anim.SetBool("isJumping", true);
                    anim.SetBool("isWalking", false);
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
            }

            else
            {
                anim.SetBool("isJumping", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 20f;
                anim.SetBool("isSprinting", true);

                if (Input.GetMouseButton(0))
                {
                    anim.SetTrigger("isRunPunch");
                    punchTrigger.SetActive(true);
                }
                //anim.SetBool("isWalking", false);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 10f;
                anim.SetBool("isSprinting", false);
                anim.SetBool("isWalking", true);
            }

            if (Input.GetMouseButton(0))
            {
                Debug.Log("Click mouse");

                if (anim.GetBool("isWalking") == true || anim.GetBool("isSprinting") == true)
                {
                    Debug.Log("Run punch");

                    anim.SetTrigger("isRunPunch");
                    punchTrigger.SetActive(true);
                }

                if (anim.GetBool("isWalking") == false && anim.GetBool("isSprinting") == false)
                {
                    Debug.Log("Walk punch");

                    anim.SetTrigger("isPunching");
                    punchTrigger.SetActive(true);
                }
            }


            else
            {
                punchTrigger.SetActive(false);
            }

            directionY -= gravity * Time.deltaTime;

            worldMoveInput.y = directionY;

            controller.Move(worldMoveInput * speed * Time.deltaTime);

            if (playerHitPoints <= 0)
            {
                FindObjectOfType<MenuButtons>().EnterGameOver();
            }
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCounter++;
            Debug.Log(coinCounter);
        }
        if (other.gameObject.CompareTag("EndTrigger"))
        {
            if (coinCounter == 3)
            {
               SceneManager.LoadScene("EndGame");
               
            }
            else
            {
                print("Get All Coins");
            }
        }
        if (other.gameObject.tag == "Enemy")
        {
            playerHitPoints -= playerDamage;
            print(playerHitPoints);
            anim.SetBool("isHit", true);
            
        }
        if (other.tag == "Water")
        {
            playerHitPoints -= waterDamage;
        }
        if (other.gameObject.tag == "Burger")
        {
            if (playerHitPoints >= 100)
            {
                healthUp = 0;
            }

            else
            {
                healthUp = 5;
            }
            playerHitPoints += healthUp;
            Destroy(other.gameObject);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            anim.SetBool("isHit", false);
            
        }
    }
   

}
