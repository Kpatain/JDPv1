using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    [SerializeField] float velocity = 1f;
    [SerializeField] SpriteRenderer jsM;
    [SerializeField] SpriteRenderer jsF;
    [SerializeField] Vector3 maxVelocity;
    [SerializeField] Vector3 minVelocity;



    void Start()
    {
        minVelocity = -maxVelocity;
    }

    void Update()
    {
        //Movement();
        //maxVelo();

    }


    public void Movement()
    {
        Vector3 temp = jsM.transform.position - jsF.transform.position;
        temp.z = temp.y;
        temp.y = -9/velocity;
        temp *= velocity;
        gameObject.GetComponent<Rigidbody>().velocity = temp;
    }

    void maxVelo()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 10 )
        {
            gameObject.GetComponent<Rigidbody>().velocity *= 0.1f;
        }

    }
}
