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
    float rdm;

    // Start is called before the first frame update
    void Start()
    {
        rdm = Random.Range(0, 10000);
        smoothTime = Random.Range(0.2f, 0.5f);
        smoothTimeRotation = Random.Range(0.1f, 0.4f);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = GameManager.Instance.paperPColors[index];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 buff = transform.GetChild(0).transform.localPosition;
        buff.y = Mathf.PerlinNoise(rdm, Time.time)*10;
        transform.GetChild(0).transform.localPosition = buff;
        gameObject.GetComponent<NavMeshAgent>().destination = objectif.transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.SmoothDamp(transform.forward, norme.normalized, ref velocity, smoothTimeRotation));
        
    }

}
