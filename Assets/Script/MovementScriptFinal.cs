using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovementScriptFinal : MonoBehaviour
{

    public float velocity;
    public float maxVelocity;
    Vector3 direction;
    public Joystick joystick;

    [SerializeField] public Image lys;
    [SerializeField] public Camera cam;


    public Vector3 destroyPosition;
    public Vector3 buff;
    private Vector3 oldPosition = Vector3.zero;

    


    [SerializeField] GameObject planes;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        buff = Vector3.zero;

        CameraMov();
        
        direction.x = joystick.Horizontal*4;
        direction.z = joystick.Vertical*4;


        direction.y = 0;
        Vector3 temp = direction * velocity * Time.deltaTime;


        if (temp.magnitude * 100 > maxVelocity)
        {
            temp = direction.normalized * maxVelocity * Time.deltaTime;
        }

        RaycastHit hit2;
        Ray downRay2 = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(downRay2, out hit2))
        {
            if (hit2.distance < 1f && hit2.transform.gameObject.tag == "sol")
            {
                //temp.x -= temp.x*2f;
                //temp.z -= temp.z*2f;
           }

        }
        this.transform.position += temp;

        oldPosition = gameObject.transform.position;


        //sol position

        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.transform.gameObject.tag == "sol")
            {
                Vector3 pos = transform.position;
                pos.y += 1.690102f - hit.distance;
                transform.position = pos;
            }
        }
    }

    void CameraMov()
    {
        for (int i = 0; i < planes.transform.childCount; i++)
        {
            buff += planes.transform.GetChild(i).transform.position;

        }


        buff /= planes.transform.childCount;


        transform.GetChild(0).transform.position = buff;
        
        buff.z -= 60f;
        buff.y += 50;
        cam.transform.position = buff;
    }

    

}
