using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Boid))]
public class BoidZone : MonoBehaviour
{
    private Boid boid;


    public float radius;
    public float boundaryForce;
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boid.transform.position.magnitude > radius)
        {
            boid.velocity +=this.transform.position.normalized * (radius- boid.transform.position.magnitude) * boundaryForce * Time.deltaTime;
        }
        
    }
}
