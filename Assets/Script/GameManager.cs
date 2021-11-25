using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] ParticleSystem paperPlane;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hudFlowers(Image hud)
    {

    }

    public void pause(Image img)
    {
        img.GetComponent<Animator>().SetTrigger("enter");
    }

    public void retourPause(Image img)
    {
        img.GetComponent<Animator>().SetTrigger("out");
    }
}
