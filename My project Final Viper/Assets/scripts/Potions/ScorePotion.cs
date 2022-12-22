using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePotion : MonoBehaviour
{
    //public GameObject pickupEffect;
    public float scoremultiplier = 5f;
    public float duration = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        //  Instantiate(pickupEffect, transform.position, transform.rotation);
        Growth stats = player.GetComponent<Growth>();
        stats.factor += scoremultiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.factor -= scoremultiplier;
        Destroy(gameObject);
    }
}
