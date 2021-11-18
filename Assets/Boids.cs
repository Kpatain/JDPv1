using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{

    [SerializeField] SpriteRenderer jsM;
    [SerializeField] SpriteRenderer jsF;
    [SerializeField] float velocity = 1f;
    [SerializeField] float hauteur;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = jsM.transform.position - jsF.transform.position;
        temp.z = temp.y;
        temp *= velocity;
        temp.y = 0;
        gameObject.GetComponent<Rigidbody>().velocity = temp;
    }
}
