using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementS : MonoBehaviour
{

    public float velocity;
    public float maxVelocity;
    Vector3 oldPosition = Vector3.zero;
    Vector3 direction;
    public Joystick joystick;

    [SerializeField] Image lys;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        direction.x = joystick.Horizontal*4;
        direction.z = joystick.Vertical*4;


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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lys")
        {
            lys.GetComponent<Animator>().SetTrigger("enter");
        }
    }

}
