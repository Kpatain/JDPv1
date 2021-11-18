using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joystickScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer jsM;
    [SerializeField] SpriteRenderer jsF;

    //BOOL
    bool hadTouch = false;
    bool inJS = true;


    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);

    }

    void Update()
    {
        control();
    }

    public void control()
    {
        Vector3 jsfPos = jsF.transform.localPosition;
        Vector3 jsmPos = jsM.transform.localPosition;



        //PC
        if (Input.GetMouseButtonDown(0) && !hadTouch)                       //Click
        {

            gameObject.transform.localScale = new Vector3(1,1,1);
            Vector3 temp = Input.mousePosition;
            temp.x -= Screen.width/2;
            temp.y -= Screen.height/2;
            jsfPos.x = temp.x;
            jsfPos.y = temp.y;

            jsF.transform.localPosition = jsfPos;
            hadTouch = true;
        }

        if (Input.GetMouseButton(0))                                        //click et reste
        {
            float hyp = Mathf.Sqrt(Mathf.Abs(jsmPos.x - jsfPos.x) + Mathf.Abs(jsmPos.y - jsfPos.y));

            //trop loin ?
            
            /*
            if (hyp > 116)
            {
                thalesEtTout(hyp);
            }
            else 
            {
                Vector3 temp = Input.mousePosition;
                temp.x -= Screen.width / 2;
                temp.y -= Screen.height / 2;
                jsmPos.x = temp.x;
                jsmPos.y = temp.y;
                jsM.transform.localPosition = jsmPos;
                Debug.Log("DragDedans");
            }
            */

            if (!inJS)
            {
                thalesEtTout(hyp);
            }
            else
            {
                Vector3 temp = Input.mousePosition;
                temp.x -= Screen.width / 2;
                temp.y -= Screen.height / 2;
                jsmPos.x = temp.x;
                jsmPos.y = temp.y;
                jsM.transform.localPosition = jsmPos;
            }





        }

        else if (Input.GetMouseButtonUp(0))                                 //arrete de cliquer
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            hadTouch = false;
        }
    }

    void thalesEtTout(float hyp)
    {
        Vector3 jsfPos = jsF.transform.localPosition;
        Vector3 jsmPos = jsM.transform.localPosition;

        Vector3 temp = Input.mousePosition;
        temp.x -= Screen.width / 2;
        temp.y -= Screen.height / 2;
        jsmPos.x = ((gameObject.GetComponent<SphereCollider>().radius) / hyp) * (temp.x - gameObject.GetComponent<SphereCollider>().radius);
        jsmPos.y = ((gameObject.GetComponent<SphereCollider>().radius) / hyp) * (temp.y - gameObject.GetComponent<SphereCollider>().radius);
        jsM.transform.localPosition = jsmPos;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In");
        if (other.gameObject.tag == "joystickMov")
        {
            inJS = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out");
        if (other.gameObject.tag == "joystickMov")
        {
            //inJS = false;
        }
    }
}
