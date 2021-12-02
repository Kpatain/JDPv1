using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool ui = false;
    float moy = 0;
    [SerializeField] GameObject firework;

    [SerializeField] ParticleSystem paperPlane;
    [SerializeField] public Color[] paperPColors;
    [SerializeField] public Camera cam;
    [SerializeField] GameObject player;
    Image img2;


    // Start is called before the first frame update
    void Start()
    {

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
        img.GetComponent<Animator>().SetTrigger("out");
        GameObject vfx = Instantiate(firework, player.transform.GetChild(0).transform);
        Debug.Log("test");
        Destroy(vfx, 5f);
    }

    

private void Awake()
    {
        Instance = this;
    }
}
