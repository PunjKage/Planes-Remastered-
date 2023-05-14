using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public GameObject camera = null;
    public GameObject cam1 = null;
    public GameObject cam2 = null;
    public GameObject cam3 = null;

    public GameObject plane01;
    public GameObject plane02;
    public GameObject plane03;

    private bool plane1 = false;
    private bool plane2 = false;
    private bool plane3 = false;

    // Start is called before the first frame update
    void Start()
    {
        camera.SetActive(true);
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            camera.SetActive(false);
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            plane1 = true;
            plane2 = false;
            plane3 = false;
            
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            camera.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam1.SetActive(false);
            // plane02.AddComponent<PlaneController>();
            plane2 = true;
            plane1 = false;
            plane3 = false;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            camera.SetActive(false);
            cam3.SetActive(true);
            cam1.SetActive(false);
            cam2.SetActive(false);
            plane3 = true;
            plane1 = false;
            plane2 = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            camera.SetActive(true);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            plane1 = false;
            plane2 = false;
            plane3 = false;
        }
        if(Input.GetKey(KeyCode.F))
        {
            // plane01.AddComponent<PlaneController>();
            Debug.Log(plane1);
            Debug.Log(plane2);
            Debug.Log(plane3);

        }
    }
}
