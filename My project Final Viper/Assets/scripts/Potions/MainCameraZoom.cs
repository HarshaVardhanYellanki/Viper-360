using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraZoom : MonoBehaviour
{

    public int normal = 5;
    public int smooth = 5;
    public int zoom = 0;
    GameObject obj;

    void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        
    }



    void Update()
    {
        zoom = obj.GetComponent<PlayerZoom>().zoom1;


        if (zoom==10)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoom, Time.deltaTime * smooth);
        }

        else
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, normal, Time.deltaTime * smooth);
        }
    }
}
