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
    [SerializeField] GameObject firework;

    [SerializeField] Canvas canvas;
    [SerializeField] Button quetebutton;
    [SerializeField] GameObject video;
    [SerializeField] public Color[] paperPColors;
    [SerializeField] public Camera cam;
    [SerializeField] GameObject player;
    [SerializeField] public Material trprt;
    Image img2;

    int coups;


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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            retourPause(img2);
        }


        
        moy += Time.deltaTime;
    }

    public void hudFlowers(Image hud)
    {

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
        Invoke("reactivateUI", 2f);
        img.GetComponent<Animator>().SetTrigger("out");

    }

    public void lier(Image img)
    {
        canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button").GetChild(0).gameObject.SetActive(true);
        canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2").GetChild(0).gameObject.SetActive(true);
        canvas.GetComponent<canvas_event>().QueteImage.transform.Find("Image").gameObject.SetActive(true);
        coups += 1;
        quetebutton.transform.GetChild(0).gameObject.SetActive(true);
        ui = false;
        for(int i =0; i < canvas.GetComponent<canvas_event>().quete.Count; i++)
        {
            if (img == canvas.GetComponent<canvas_event>().quete[i])
            {
                canvas.GetComponent<canvas_event>().quete[i+1].GetComponent<FlowerScript>().stade = 2;
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

    void reactivateUI()
    {
        ui = false;
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
