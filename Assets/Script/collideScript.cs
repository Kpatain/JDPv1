using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideScript : MonoBehaviour
{
    

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
        if (other.gameObject.tag == "lys" && !GameManager.Instance.ui)
        {
            transform.parent.GetComponent<MovementScriptFinal>().lys.GetComponent<Animator>().SetTrigger("enter");
            GameManager.Instance.ui = true;
        }
    }
}
