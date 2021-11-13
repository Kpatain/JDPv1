using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    [SerializeField] float velocity = 1f;
    [SerializeField] SpriteRenderer jsM;
    [SerializeField] SpriteRenderer jsF;


    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }


    public void Movement()
    {
        Vector3 temp = jsM.transform.position - jsF.transform.position;
        temp.z = temp.y;
        temp.y = -9/velocity;
        temp *= velocity;
        gameObject.GetComponent<Rigidbody>().velocity = temp;
    }

}
