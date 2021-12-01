using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 buff = transform.parent.GetComponent<MovementScriptFinal>().cam.transform.position;
        buff.z += 20f;
        buff.y = 3f;
        transform.position = buff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lys")
        {
            Debug.Log("collide");
            transform.parent.GetComponent<MovementScriptFinal>().lys.GetComponent<Animator>().SetTrigger("enter");
        }
    }
}
