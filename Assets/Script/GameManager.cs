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
    [SerializeField] GameObject location;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject tuto;
    [SerializeField] Button quetebutton;
    [SerializeField] Button puzzle1;
    [SerializeField] Button puzzle2;
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
    [SerializeField] TextMeshPro flowerTXT;
    [SerializeField] Material red;
    [SerializeField] Material orange;

    [SerializeField] ParticleSystem burst;


    [SerializeField] public GameObject lysObj;
    [SerializeField] public GameObject amarObj;
    [SerializeField] public GameObject helenieObj;
    public GameObject questFlower;

    public bool jsMode = false;
    public bool tapMode = true;
    bool once2 = true;

    int coups;
    Image img2;

    Vector3 velocity = Vector3.one;
    Vector3 buff = Vector3.zero;

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
        if (canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Image").transform.Find("Button") == null
                && canvas.GetComponent<canvas_event>().PuzzleImage.transform.Find("Image").transform.Find("Button2") == null
                && once2)
        {
            Invoke("rdmInvoke", 10f);
            once2 = false;
            inTUto = true;
            tuto.transform.GetChild(tuto.transform.childCount-1).GetComponent<Animator>().SetTrigger("in");
        }

        if (Vector3.Distance(buff, player.transform.position) < 2f)
        {
            location.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && tapMode)
        {
            Ray ray = cam.ScreenPointToRay(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                

                if (hit.transform.gameObject.tag == "sol" && !ui)
                {
                    FindObjectOfType<AudioManager>().Play("target");
                    buff = hit.point;
                    
                    buff.y += 1f;
                    
                    player.GetComponent<NavMeshAgent>().destination = buff;
                    Vector3 buff2 = hit.point;
                    buff2.y += 2f;
                    location.gameObject.SetActive(true);
                    location.transform.GetChild(0).GetComponent<Animator>().SetTrigger("anim");
                    location.transform.position = buff2;


                }
                else if(hit.transform.gameObject.tag == "amar" && !ui)
                {
                    FindObjectOfType<AudioManager>().Play("target");
                    buff = amarObj.transform.position;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                    Vector3 buff2 = hit.point;
                    buff2.y += 2f;
                    location.gameObject.SetActive(true);
                    location.transform.GetChild(0).GetComponent<Animator>().SetTrigger("anim");
                    location.transform.position = buff2;

                }
                else if (hit.transform.gameObject.tag == "lys" && !ui)
                {
                    FindObjectOfType<AudioManager>().Play("target");
                    buff = lysObj.transform.position;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                    Vector3 buff2 = hit.point;
                    buff2.y += 2f;
                    location.gameObject.SetActive(true);
                    location.transform.GetChild(0).GetComponent<Animator>().SetTrigger("anim");
                    location.transform.position = buff2;

                }
                else if (hit.transform.gameObject.tag == "helenie" && !ui)
                {
                    FindObjectOfType<AudioManager>().Play("target");
                    buff = helenieObj.transform.position;
                    buff.y += 1f;
                    player.GetComponent<NavMeshAgent>().destination = buff;
                    Vector3 buff2 = hit.point;
                    buff2.y += 2f;
                    location.gameObject.SetActive(true);
                    location.transform.GetChild(0).GetComponent<Animator>().SetTrigger("anim");
                    location.transform.position = buff2;

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
        img.gameObject.SetActive(!img.gameObject.activeSelf);
        Debug.Log("menu");
        img.GetComponent<Animator>().SetTrigger("enter");
        FindObjectOfType<AudioManager>().Play("pop");

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
        FindObjectOfType<AudioManager>().Play("popOUT");
        ui = false;
        img.GetComponent<Animator>().SetTrigger("out");
        StartCoroutine(reactive(img));

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
        FindObjectOfType<AudioManager>().Play("firework");
        FindObjectOfType<AudioManager>().Play("link");

        if (img.name == "Helenie_Menu" || img.name == "Lys_Menu") 
        {
            canvas.GetComponent<canvas_event>().QueteImage.transform.Find("Image").gameObject.SetActive(true);
            if (puzzle1 != null)
            {
                puzzle1.transform.GetChild(0).gameObject.SetActive(true);
            }

            if (puzzle2 != null)
            {
                puzzle2.transform.GetChild(0).gameObject.SetActive(true);
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
            flowerTXT.gameObject.SetActive(true);
            coups += 1;
            Invoke("tutoPuzzle", 2f);
            questFlower = amarObj;
            player.GetComponent<MovementScriptFinal>().directionArrow.transform.GetChild(0).GetComponent<SpriteRenderer>().material = red;
        }
        else if (questFlower == amarObj)
        {
            flowerTXT.text = "xP";
            questFlower = helenieObj;
            player.GetComponent<MovementScriptFinal>().directionArrow.transform.GetChild(0).GetComponent<SpriteRenderer>().material = orange;
        }
        else
        {
            flowerTXT.text = "xx";
            coups += 1;
        }
    }

    void tutoPuzzle()
    {
        tuto.transform.Find("7(Puzzle)").GetComponent<Animator>().SetTrigger("in");
        FindObjectOfType<AudioManager>().Play("paper");
        inTUto = true;
    }

    public void skipVideo()
    {
        GetComponent<AudioSource>().enabled = true;
        if (video != null)
        {

            stopVideo();
            Destroy(video);
        }

        tuto.transform.GetChild(0).GetComponent<Animator>().SetTrigger("in");
        FindObjectOfType<AudioManager>().Play("paper");
        ui = true;
        inTUto = true;
        FindObjectOfType<AudioManager>().Play("popOUT");
    }

    private void stopVideo()
    {
        GetComponent<AudioSource>().enabled = true;
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
            FindObjectOfType<AudioManager>().Play("puzzle");
            coups -= 1;
            burst.transform.position = btn.transform.position;
            burst.Play();
            Destroy(btn.gameObject);
            

            if (puzzle1 != null)
            {
                puzzle1.transform.GetChild(0).gameObject.SetActive(false);
            }

            if (puzzle2 != null)
            {
                puzzle2.transform.GetChild(0).gameObject.SetActive(false);
            }

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

    IEnumerator reactive(Image img)
    {
        yield return new WaitForSeconds(1);
        img.gameObject.SetActive(!img.gameObject.activeSelf);
    }
}
