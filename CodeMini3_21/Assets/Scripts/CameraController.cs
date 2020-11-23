using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject PlayerModel;

    Vector3 posOffset = new Vector3(3.0f, 2.0f, 2.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerModel.transform.position + posOffset, 0.1f);
    }
}
