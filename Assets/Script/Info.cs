using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager.Instance.cam.transform);
        Quaternion rot = transform.rotation;
        rot.z = 0f;
        rot.x = 0f;
        transform.rotation = rot;
    }
}
