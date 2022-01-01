using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideScript : MonoBehaviour
{

    bool recollide = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lys" && !GameManager.Instance.ui && recollide)
        {
            GameManager.Instance.pause(transform.parent.GetComponent<MovementScriptFinal>().lys);
            
            GameManager.Instance.ui = true;
            recollide = false;
            Invoke("recollideF", 10f);
        }

        if (other.gameObject.tag == "amar" && !GameManager.Instance.ui && recollide)
        {
            GameManager.Instance.pause(transform.parent.GetComponent<MovementScriptFinal>().amar);
            GameManager.Instance.ui = true;
            recollide = false;
            Invoke("recollideF", 10f);
        }

        if (other.gameObject.tag == "helenie" && !GameManager.Instance.ui && recollide)
        {
            GameManager.Instance.pause(transform.parent.GetComponent<MovementScriptFinal>().helenie);
            GameManager.Instance.ui = true;
            recollide = false;
            Invoke("recollideF", 10f);
        }
    }

    void recollideF()
    {
        recollide = true;
    }
}
