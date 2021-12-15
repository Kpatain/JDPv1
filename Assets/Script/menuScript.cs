using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] Image Info;
    Vector3 velocity = Vector3.one;

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
        Debug.Log("pouet");
        Info.gameObject.SetActive(true);
        Vector3 buff = Info.transform.position;
        buff.y += Screen.height;
        Info.transform.position = buff;
        buff = Vector3.zero;
        Info.transform.position = Vector3.SmoothDamp(Info.transform.position, buff, ref velocity, 1f);
        //StartCoroutine(StateImg(Info));
        //Info.GetComponent<Animator>().SetTrigger("enter");
    }

    public void CreditOut()
    {
        Info.GetComponent<Animator>().SetTrigger("out");
    }

    private IEnumerator StateImg(Image img)
    {
        yield return new WaitForSeconds(1f);

        img.gameObject.SetActive(!img.gameObject.activeSelf);

    }
}
