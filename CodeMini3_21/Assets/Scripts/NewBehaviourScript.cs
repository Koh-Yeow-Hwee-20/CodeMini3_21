using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Renderer playerRdr;
    public Material[] playerMtrs;

    // Start is called before the first frame update
    void Start()
    {
        playerRdr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        playerRdr.material.color = playerMtrs[1].color;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRdr.material.color = playerMtrs[0].color;
        }
    }
    
}
