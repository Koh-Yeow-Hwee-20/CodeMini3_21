using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaneController : MonoBehaviour
{
    float zUpperLimit = -20.3f;
    float zLowerLimit = -32.35f;
    float moveSpeed = 5.0f;

    bool isMoveFwd = false;
    bool isMoveBack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveBack && !isMoveFwd)
        {
            if (transform.position.x >= zLowerLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            else
            {
                isMoveBack = !isMoveBack;
                isMoveFwd = !isMoveFwd;
            }
        }

        if (isMoveFwd && !isMoveBack)
        {
            if(transform.position.x <= zUpperLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
            else
            {
                isMoveBack = !isMoveBack;
                isMoveFwd = !isMoveFwd;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }


}
