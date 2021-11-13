using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erudiScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 play = player.transform.position;
            gameObject.transform.LookAt(play);
        }
    }
}
