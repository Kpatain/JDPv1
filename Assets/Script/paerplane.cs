using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class paerplane : MonoBehaviour
{
    [SerializeField] int index;
    private Vector3 obj;

    [SerializeField] GameObject objectif;
    private Vector3 norme = Vector3.zero;
    private Vector3 buff1 = Vector3.zero;
    private Vector3 buff2 = Vector3.zero;

    public float smoothTime = 0f;
    public float smoothTimeRotation = 0f;
    private Vector3 velocity = Vector3.one;


    private Material colorMAt;


    // Start is called before the first frame update
    void Start()
    {
        smoothTime = Random.Range(0.2f, 0.5f);
        smoothTimeRotation = Random.Range(0.1f, 0.4f);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = GameManager.Instance.paperPColors[index];
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<NavMeshAgent>().destination = objectif.transform.position;

        buff1 = gameObject.transform.position;
        buff2 = objectif.transform.position;
        norme = buff2 - buff1;
        obj = objectif.transform.position;
        obj.y += Random.Range(-2f, 2f);
        obj.x += Random.Range(-2f, 2f);
        obj.y += Random.Range(-2f, 2f);

        //transform.position = Vector3.SmoothDamp(transform.position, obj, ref velocity, smoothTime);
        transform.rotation = Quaternion.LookRotation(Vector3.SmoothDamp(transform.forward, norme.normalized, ref velocity, smoothTimeRotation));
        
    }

}
