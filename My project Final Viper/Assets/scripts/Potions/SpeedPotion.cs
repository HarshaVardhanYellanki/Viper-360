using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    //public GameObject pickupEffect;
    public float speedmultiplier = 5f;
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
        Movement stats = player.GetComponent<Movement>();
        stats.Speed *= speedmultiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.Speed /= speedmultiplier;
        Destroy(gameObject);
    }
}
