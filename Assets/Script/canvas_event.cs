using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class canvas_event : MonoBehaviour
{
    
    [SerializeField] Image Pause;
    [SerializeField] public Image QueteImage;
    [SerializeField] public Image PuzzleImage;
    [SerializeField] Image Carte;
    [SerializeField] TextMeshProUGUI queteText;

    [SerializeField] public List<Image> quete;

    [SerializeField] [TextArea] string queteTexte1;
    [SerializeField] [TextArea] string queteTexte2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0;i < quete.Count; i++)
        {
            if(quete[i].GetComponent<FlowerScript>().stade == 2)
            {
                if (i == 0)
                {
                    queteText.text = queteTexte1;
                    quete[i].transform.Find("Lié").gameObject.SetActive(true);
                }

                else
                {
                    queteText.text = queteTexte2;
                    quete[i].transform.Find("Lié").gameObject.SetActive(true);
                }
            }

            if (quete[i].GetComponent<FlowerScript>().stade == 3)
            {
                quete[i].transform.Find("Lié").gameObject.SetActive(false);
            }
        }  
    }

    void retourDesactivate(Image img)
    {
        img.transform.Find("Lié").gameObject.SetActive(false);
    }
}
