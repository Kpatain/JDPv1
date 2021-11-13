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
        Movement();
        maxVelo();
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
        if (gameObject.GetComponent<Rigidbody>().velocity.x > maxVelocity.x )
        {
            Vector3 temp = gameObject.GetComponent<Rigidbody>().velocity;
            temp.x = maxVelocity.x - maxVelocity.x * 0.1f;
            gameObject.GetComponent<Rigidbody>().velocity = temp;
        }

        else if (gameObject.GetComponent<Rigidbody>().velocity.z > maxVelocity.z)
        {
            Vector3 temp = gameObject.GetComponent<Rigidbody>().velocity;
            temp.z = maxVelocity.z - maxVelocity.z * 0.1f;
            gameObject.GetComponent<Rigidbody>().velocity = temp;
        }

        else if (gameObject.GetComponent<Rigidbody>().velocity.x < minVelocity.x)
        {
            Vector3 temp = gameObject.GetComponent<Rigidbody>().velocity;
            temp.x = minVelocity.z + minVelocity.z * 0.1f;
            gameObject.GetComponent<Rigidbody>().velocity = temp;
        }

        else if (gameObject.GetComponent<Rigidbody>().velocity.z < minVelocity.z)
        {
            Vector3 temp = gameObject.GetComponent<Rigidbody>().velocity;
            temp.z = minVelocity.z + minVelocity.z * 0.1f;
            gameObject.GetComponent<Rigidbody>().velocity = temp;
        }

    }
}
