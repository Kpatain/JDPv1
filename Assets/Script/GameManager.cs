using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool ui = false;
    float moy = 0;

    [SerializeField] Canvas canvas;
    [SerializeField] Button quetebutton;
    [SerializeField] GameObject video;
    [SerializeField] public Color[] paperPColors;
    [SerializeField] public Camera cam;
    [SerializeField] GameObject player;
    [SerializeField] public Material trprt;
    [SerializeField] ParticleSystem firework;
    [SerializeField] GameObject collide;

    int coups;
    Image img2;

    void Start()
    {
        coups = 0;
        Application.targetFrameRate = 30;
        video.SetActive(true);
        video.transform.GetChild(1).GetComponent<VideoPlayer>().Play();
        Invoke("stopVideo", 50f);
        Destroy(video, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        
        //coup dispo
        canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("cliquerestant").GetComponent<TMP_Text>().text = coups.ToString() + " COUP(S) DISPONIBLE(S)";
        if (coups == 0)
        {
            if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button") != null)
            {
                canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button").GetChild(0).gameObject.SetActive(false);
            }

            if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button") != null)
            {
                canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2").GetChild(0).gameObject.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape) && ui)
        {
            
            retourPause(img2);
        }


        
        moy += Time.deltaTime;
    }


    public void pause(Image img)
    {
        Debug.Log("menu");
        img.GetComponent<Animator>().SetTrigger("enter");
        ui = true;
        img2 = img;

        if (img == canvas.GetComponent<canvas_event>().QueteImage)
        {
            quetebutton.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (img.name == canvas.GetComponent<canvas_event>().PuzzleImage.name)
        {
            canvas.GetComponent<canvas_event>().QueteImage.transform.Find("Image").gameObject.SetActive(false);
        }
    }

    public void retourPause(Image img)
    {
        ui = false;
        img.GetComponent<Animator>().SetTrigger("out");
    }

    public void lier(Image img)
    {
        firework.transform.position = collide.transform.position;
        firework.Play();
        if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button") != null)
        {
            canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button").GetChild(0).gameObject.SetActive(false);
        }

        if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2") != null)
        {
            canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2").GetChild(0).gameObject.SetActive(false);
        }

        canvas.GetComponent<canvas_event>().QueteImage.transform.Find("Image").gameObject.SetActive(true);

        coups += 1;

        quetebutton.transform.GetChild(0).gameObject.SetActive(true);

        for(int i =0; i < canvas.GetComponent<canvas_event>().quete.Count; i++)
        {
            if (img == canvas.GetComponent<canvas_event>().quete[i] && img.name != "Helenie_Menu")
            {
                canvas.GetComponent<canvas_event>().quete[i + 1].GetComponent<FlowerScript>().stade = 2;  
            }
        }
        
        img.GetComponent<FlowerScript>().stade = 3;
        img.GetComponent<Animator>().SetTrigger("out");

    }

    public void skipVideo()
    {
        if (video != null)
        {

            stopVideo();
            Destroy(video);
        }
    }

    private void stopVideo()
    {
        if (video != null)
        {
            video.transform.GetChild(1).GetComponent<VideoPlayer>().Stop();
        }
       
    }



    private void Awake()
    {
        Instance = this;
    }

    public void piecePuzzle(Button btn)
    {
        if (coups > 0)
        {
            coups -= 1;
            Destroy(btn.gameObject);
        }

    }
}
