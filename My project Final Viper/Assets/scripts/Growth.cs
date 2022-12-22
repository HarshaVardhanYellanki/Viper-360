using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Growth : MonoBehaviour
{
    public Follow snaketail;
    public TextMeshProUGUI Letters;
    public float Score = 0f;
    public float factor=0f;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Destroy(collision.gameObject, 0.02f);
            snaketail.AddTail();
            if(factor==5)
            {
                Score += 50;
            }
            else{
                Score += 10;
            }

            Letters.text = " Score : " + Score;
        }
    }
}
