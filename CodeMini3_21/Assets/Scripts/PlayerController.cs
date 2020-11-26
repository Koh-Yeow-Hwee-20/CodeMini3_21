using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool isOnGround;
    float jumpForce = 10.0f;
    float gravityModifier = 2.0f;
    float speed = 5.0f;
  //public float timer;

    public GameObject PowerUpCollected;
    public Animator playerAnim;
    public Animator planeB;
    public Rigidbody playerRb;
    public Renderer playerRdr;
  //public GameObject Timer;

    private int powerUp;
    private int totalPowerUp;

    public Material[] playerMtrs;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRdr = GetComponent<Renderer>();
        isOnGround = true;
        Physics.gravity *= gravityModifier;

        totalPowerUp = GameObject.FindGameObjectsWithTag("PowerUp").Length;
    //  Timer.GetComponent<Text>().text = "Timer: " + timer.ToString("10");
    }

    // Update is called once per frame
    void Update()
    {
        //float verticalInput = Input.GetAxis("Vertical");
        //float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            startRun();
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            startRun();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            startRun();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            startRun();
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRun", false);
        }

        void startRun()
        {
            playerAnim.SetBool("isRun", true);
            playerAnim.SetFloat("startRun", 0.26f);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if(transform.position.y < -5)
        {
            SceneManager.LoadScene("GameOver");
        }
        PlayerJump();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ConeTag") || powerUp < 4)
        {
            Debug.Log("Collect 4 PowerUps first");
        }

        if (powerUp == 4)
        {
            Debug.Log("Activated PlaneB 90Deg rotation");
            planeB.SetBool("RotateState", true);
        }
        if (other.gameObject.tag == "PowerUp")
        {
            powerUp++;
            PowerUpCollected.GetComponent<Text>().text = "PowerUp Collected: " + powerUp;

            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            isOnGround = true;
            playerRdr.material.color = playerMtrs[1].color;
        }
    }
    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerRdr.material.color = playerMtrs[0].color;

        }
    }
}
