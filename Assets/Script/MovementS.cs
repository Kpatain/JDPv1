using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementS : MonoBehaviour
{

    [SerializeField] SpriteRenderer jsM;
    [SerializeField] SpriteRenderer jsF;
    public float velocity;
    public float maxVelocity;
    Vector3 oldPosition = Vector3.zero;

    //
    bool canPlay = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = jsM.transform.position - jsF.transform.position;


        direction.y = 0;
        Vector3 temp = direction * velocity * Time.deltaTime;


        if (temp.magnitude * 100 > maxVelocity)
        {
            Debug.Log("max");
            temp = direction.normalized * maxVelocity * Time.deltaTime;
        }
        this.transform.position += temp;


        oldPosition = gameObject.transform.position;
    }

    void animationOneTime()
    {
        canPlay = true;
    }

}
