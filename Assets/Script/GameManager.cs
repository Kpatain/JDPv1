using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject video;
    [SerializeField] public Color[] paperPColors;
    [SerializeField] public Camera cam;
    [SerializeField] GameObject player;
    [SerializeField] public Material trprt;
    Image img2;




    void Start()
    {


        Application.targetFrameRate = 30;
        video.SetActive(true);
        video.transform.GetChild(0).GetComponent<VideoPlayer>().Play();
        Invoke("stopVideo", 50f);
        Destroy(video, 50f);
    }

    // Update is called once per frame
    void Update()
    {
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
        img.GetComponent<Animator>().SetTrigger("enter");
        ui = true;
        img2 = img;
    }

    public void retourPause(Image img)
    {
        ui = false;
        img.GetComponent<Animator>().SetTrigger("out");
    }

    public void lier(Image img)
    {
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
        GameObject vfx = Instantiate(firework, player.transform.GetChild(0).transform);
        Debug.Log("test");
        Destroy(vfx, 5f);
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
            video.transform.GetChild(0).GetComponent<VideoPlayer>().Stop();
        }
       
    }

    ///EVENT FLEUR QUETE
    ///


    private void Awake()
    {
        Instance = this;
    }
}
