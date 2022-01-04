using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] Image Info;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Info.gameObject.SetActive(false);
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
        Info.gameObject.SetActive(!Info.gameObject.activeSelf);
        Info.GetComponent<Animator>().SetTrigger("enter");
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void CreditOut()
    {
        Info.GetComponent<Animator>().SetTrigger("out");
        FindObjectOfType<AudioManager>().Play("buttonOff");
        Invoke("reactive", 1f);
    }

    void reactive()
    {
        Info.gameObject.SetActive(!Info.gameObject.activeSelf);
    }
}
