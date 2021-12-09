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
    [SerializeField] public Image amar;
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


        Step(temp);

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
                //transform.position = pos;
            }
        }
    }

    void Step(Vector3 temp)
    {
        Vector3 newposition = transform.position + temp;
        NavMeshHit hit;
        bool isValid = NavMesh.SamplePosition(newposition, out hit, 0.3f, NavMesh.AllAreas);
        if (isValid)
        {
            
            this.transform.position += temp;
        }
        else
        {
            Debug.Log("notvalid");
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
        
        buff.z -= 20f;
        buff.y += 15;
        cam.transform.position = buff;
    }

    

}
