using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementS : MonoBehaviour
{

    public float velocity;
    public float maxVelocity;
    Vector3 oldPosition = Vector3.zero;
    Vector3 direction;
    public Joystick joystick;

    [SerializeField] Image lys;
    [SerializeField] Camera cam;


    public Vector3 destroyPosition;
    public Vector3 buff;

    [SerializeField] ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;



    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        m_System.Simulate(Time.fixedDeltaTime, true, false, true);
    }

    // Update is called once per frame
    void Update()
    {

        
        direction.x = joystick.Horizontal*4;
        direction.z = joystick.Vertical*4;


        direction.y = 0;
        Vector3 temp = direction * velocity * Time.deltaTime;


        if (temp.magnitude * 100 > maxVelocity)
        {
            Debug.Log("max");
            temp = direction.normalized * maxVelocity * Time.deltaTime;
        }
        this.transform.position += temp;


        oldPosition = gameObject.transform.position;
    }

    private void LateUpdate()
    {
        InitializeIfNeeded();
        int numParticlesAlive = m_System.GetParticles(m_Particles);
        buff = Vector3.zero;
        for (int i = 0; i < numParticlesAlive; i++)
        {
            buff.x += (float)m_Particles[i].position.x + m_System.transform.position.x;
            buff.z += (float)m_Particles[i].position.z + m_System.transform.position.z;
        }

        
        buff.x /= numParticlesAlive;
        buff.z /= numParticlesAlive;
        buff.z -= 20f;
        buff.y = cam.transform.position.y;
        cam.transform.position = buff;

        m_System.SetParticles(m_Particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lys")
        {
            lys.GetComponent<Animator>().SetTrigger("enter");
        }
    }

}
