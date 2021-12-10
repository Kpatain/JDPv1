using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapTUTO : MonoBehaviour
{
    int actualSLide = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.inTUto)
        {
            if (actualSLide < 5)
            {
                transform.GetChild(actualSLide).GetComponent<Animator>().SetTrigger("out");
                actualSLide += 1;
                transform.GetChild(actualSLide).GetComponent<Animator>().SetTrigger("in");
            }
            else
            {
                transform.GetChild(actualSLide).GetComponent<Animator>().SetTrigger("out");
                GameManager.Instance.inTUto = false;
                actualSLide += 1;
            }
        }
            
    }
}
