using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoidAlignement : MonoBehaviour
{

    private Boid boid;


    public float radius;
    void Start()
    {
        boid = GetComponent<Boid>();
    }


    void Update()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector3.zero;
        var found = 0;
        Debug.Log(boids.GetType());
        foreach (var boid in boids.Where(b => b != boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += boid.velocity;
                found += 1;
            }
        }


        if (found > 0)
        {
            average = average / found;
            boid.velocity += Vector3.Lerp(boid.velocity, average, Time.deltaTime);
        }

    }
}
