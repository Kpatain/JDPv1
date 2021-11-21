using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity;

    //[SerializeField] SpriteRenderer jsM;
    //[SerializeField] SpriteRenderer jsF;
    //[SerializeField] float velocityf = 1f;
    //[SerializeField] float hauteur;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /////Movement
        //Vector3 temp = jsM.transform.position - jsF.transform.position;
        //temp.z = temp.y;
        //temp *= velocityf;
        //temp.y = 0;
        //gameObject.GetComponent<Rigidbody>().velocity = temp;

        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }

        this.transform.position += velocity * Time.deltaTime;
        this.transform.rotation = Quaternion.LookRotation(velocity);
    }

}
