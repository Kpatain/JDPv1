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

            gameObject.transform.localScale = new Vector3(1, 1, 1);
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
            if (hyp > jsF.size.x/2)
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

            

            
        }

        else if (Input.GetMouseButtonUp(0))                                 //arrete de cliquer
        {
            Debug.Log("Up");
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
        jsmPos.x = ((jsF.size.x / 2) / hyp) * (temp.x - jsfPos.x);
        jsmPos.y = ((jsF.size.y / 2) / hyp) * (temp.y - jsfPos.y);
        jsM.transform.localPosition = jsmPos;

        Debug.Log("DragDehors");
    }

}
