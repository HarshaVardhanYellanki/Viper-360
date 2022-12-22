using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float offset = 0.0f;
    public GameObject GameOverUI;
    public GameObject startpanel;
    public bool gamestart = false;


    void start()
    {
        startpanel.SetActive(false);
    }


    void Update()
    {
      if(gamestart == true)
      {

         Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = transform.position.z;
      
   
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);


        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);


      }
    }
    public void startgame()
    {
         startpanel.SetActive(false);
         gamestart = true;
    }
    private void gameOver()
    {
        GameOverUI.SetActive(true);
    }
    private void ResetState()
    {
        this.transform.position = Vector3.zero;
        gameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
    public void restart()
    {
        SceneManager.LoadScene("Snake");
        
    }
    public void quitgame()
    {
        Application.Quit();
    }
    
}