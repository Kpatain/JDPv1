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
            transform.parent.GetComponent<MovementScriptFinal>().lys.GetComponent<Animator>().SetTrigger("enter");
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
