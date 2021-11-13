using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ldScript : MonoBehaviour
{
    [SerializeField] string type;
    [SerializeField] Color buisson;
    [SerializeField] Color arbre;
    [SerializeField] Color eau;
    [SerializeField] Color fleur;
    [SerializeField] Color caillou;
    [SerializeField] Color tronc;
    [SerializeField] Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case "b":
                gameObject.GetComponent<Renderer>().material.color = buisson;
                break;
            case "a":
                gameObject.GetComponent<Renderer>().material.color = arbre;
                break;
            case "e":
                gameObject.GetComponent<Renderer>().material.color = eau;
                break;
            case "f":
                gameObject.GetComponent<Renderer>().material.color = fleur;
                break;
            case "c":
                gameObject.GetComponent<Renderer>().material.color = caillou;
                break;
            case "t":
                gameObject.GetComponent<Renderer>().material.color = tronc;
                break;
            default:
                gameObject.GetComponent<Renderer>().material.color = defaultColor;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
