using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool ui = false;
    bool once = true;
    float moy = 0;
    public bool inTUto = false;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject tuto;
    [SerializeField] Button quetebutton;
    [SerializeField] GameObject video;
    [SerializeField] public Color[] paperPColors;
    [SerializeField] public Camera cam;
    [SerializeField] public GameObject player;
    [SerializeField] public Material trprt;
    [SerializeField] ParticleSystem firework;
    [SerializeField] ParticleSystem firework2;
    [SerializeField] GameObject collide;
    [SerializeField] GameObject joystickOBJ;
    [SerializeField] Image Pause;

    [SerializeField] public GameObject lysObj;
    [SerializeField] public GameObject amarObj;
    [SerializeField] public GameObject helenieObj;
    public GameObject questFlower;

    public bool jsMode = false;
    public bool tapMode = true;
    bool once2 = true;

    int coups;
    Image img2;

    void Start()
    {
        coups = 0;
        Application.targetFrameRate = 30;
        video.SetActive(true);
        ui = true;
        video.transform.GetChild(1).GetComponent<VideoPlayer>().Play();
        Invoke("stopVideo", 50f);
        Destroy(video, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2") == null
                && canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button") == null
                && once2)
        {
            Invoke("rdmInvoke", 10f);
            once2 = false;
            inTUto = true;
            tuto.transform.GetChild(tuto.transform.childCount-1).GetComponent<Animator>().SetTrigger("in");
        }


        if (Input.GetMouseButtonDown(0) && tapMode)
        {
            Ray ray = cam.ScreenPointToRay(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.transform.gameObject.tag == "sol" && !ui)
                {
                    Vector3 buff = hit.point;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                }
                else if(hit.transform.gameObject.tag == "amar" && !ui)
                {
                    Vector3 buff = amarObj.transform.position;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                }
                else if (hit.transform.gameObject.tag == "lys" && !ui)
                {
                    Vector3 buff = lysObj.transform.position;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                }
                else if (hit.transform.gameObject.tag == "helenie" && !ui)
                {
                    Vector3 buff = helenieObj.transform.position;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                }
            }

        }
        //coup dispo
        canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("cliquerestant").GetComponent<TMP_Text>().text = coups.ToString() + " COUP(S) DISPONIBLE(S)";
        if (coups == 0)
        {
            if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button") != null)
            {
                canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button").GetChild(0).gameObject.SetActive(false);
            }

            if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2") != null)
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

    void rdmInvoke()
    {
        firework2.Play();
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

        if (once && img == canvas.GetComponent<canvas_event>().PuzzleImage && questFlower == amarObj)
        {
            tuto.transform.Find("8(2quete)").GetComponent<Animator>().SetTrigger("in");
            inTUto = true;
            once = false;
        }
    }

    public void lier(Image img)
    {
        firework.transform.position = collide.transform.position;
        firework.Play();
        

        if (img.name == "Helenie_Menu" || img.name == "Lys_Menu") 
        {
            canvas.GetComponent<canvas_event>().QueteImage.transform.Find("Image").gameObject.SetActive(true);
            if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button") != null)
            {
                canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button").GetChild(0).gameObject.SetActive(true);
            }

            if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2") != null)
            {
                canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Button2").GetChild(0).gameObject.SetActive(true);
            }
        }
        

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
        if (questFlower == lysObj)
        {
            canvas.GetComponent<canvas_event>().QueteImage.transform.Find("puzzleBouton").gameObject.SetActive(true);
            coups += 1;
            Invoke("tutoPuzzle", 2f);
            questFlower = amarObj;
        }
        else if (questFlower == amarObj)
        {
            canvas.GetComponent<canvas_event>().QueteImage.transform.Find("flower").GetComponent<TextMeshProUGUI>().text = "xP";
            questFlower = helenieObj;
        }
        else
        {
            canvas.GetComponent<canvas_event>().QueteImage.transform.Find("flower").GetComponent<TextMeshProUGUI>().text = "xx";
            coups += 1;
        }
    }

    void tutoPuzzle()
    {
        tuto.transform.Find("7(Puzzle)").GetComponent<Animator>().SetTrigger("in");
        inTUto = true;
    }

    public void skipVideo()
    {
        if (video != null)
        {

            stopVideo();
            Destroy(video);
        }

        tuto.transform.GetChild(0).GetComponent<Animator>().SetTrigger("in");
        ui = true;
        inTUto = true;
    }

    private void stopVideo()
    {
        if (video != null)
        {
            ui = true;
            inTUto = true;
            video.transform.GetChild(1).GetComponent<VideoPlayer>().Stop();
            Destroy(video);
            tuto.transform.GetChild(0).GetComponent<Animator>().SetTrigger("in");
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

    public void joystickMode(Image img)
    {
        //player.GetComponent<NavMeshAgent>().isStopped = true;
        player.GetComponent<NavMeshAgent>().enabled = false ;
        joystickOBJ.SetActive(true);
        jsMode = true;
        tapMode = false;
        Pause.transform.Find("Click").GetComponent<Button>().interactable = true;
        Pause.transform.Find("Joystick").GetComponent<Button>().interactable = false;

        ui = false;
        img.GetComponent<Animator>().SetTrigger("out");
    }

    public void tapModeF(Image img)
    {
        //player.GetComponent<NavMeshAgent>().isStopped = false;
        joystickOBJ.SetActive(false);
        player.GetComponent<NavMeshAgent>().enabled = true;
        jsMode = false;
        tapMode = true;
        Pause.transform.Find("Click").GetComponent<Button>().interactable = false;
        Pause.transform.Find("Joystick").GetComponent<Button>().interactable = true;

        ui = false;
        img.GetComponent<Animator>().SetTrigger("out");
    }
}
