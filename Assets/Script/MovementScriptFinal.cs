using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        this.transform.position += temp;


        oldPosition = gameObject.transform.position;
    }

    void CameraMov()
    {
        for (int i = 0; i < planes.transform.childCount; i++)
        {
            buff.x += planes.transform.GetChild(i).transform.position.x;
            buff.z += planes.transform.GetChild(i).transform.position.z;
        }


        buff.x /= planes.transform.childCount;
        buff.z /= planes.transform.childCount;
        buff.z -= 20f;
        buff.y = cam.transform.position.y;
        cam.transform.position = buff;
    }

    

}
