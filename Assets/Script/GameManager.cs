using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool ui = false;
    float moy = 0;

    [SerializeField] ParticleSystem paperPlane;
    Image img2;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

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

    
}
