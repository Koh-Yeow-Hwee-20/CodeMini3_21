using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;

    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("isRun", false);
        }

        void startRun()
        {
            playerAnim.SetBool("isRun", true);
            playerAnim.SetFloat("startRun", 0.26f);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("ConeTag"))
            {
                Debug.Log("Activated PlaneB 90Deg rotation");
            }
        }
    }
}
