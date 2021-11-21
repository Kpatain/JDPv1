using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] Image Info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jouer()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CreditIn()
    {
        Info.GetComponent<Animator>().SetTrigger("enter");
    }

    public void CreditOut()
    {
        Info.GetComponent<Animator>().SetTrigger("out");
    }
}
