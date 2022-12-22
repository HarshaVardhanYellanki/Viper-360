using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potionspawn : MonoBehaviour
{
    public GameObject[] Food;
    public float Speed;

    void Start()
    {
        InvokeRepeating("foodcopies", 0,Speed);
    }

   

    /*void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);
        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;
        Instantiate(Food, Target, Quaternion.identity);
    }*/
    public void foodcopies()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);
        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;
        int Foodindex = Random.Range(0, 4);
        Instantiate(Food[Foodindex],Target,Quaternion.identity);
    }
}