using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPotion : MonoBehaviour
{
    public int viewmultiplier = 10;
    public int duration = 10;

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
        PlayerZoom stats = player.GetComponent<PlayerZoom>();
        stats.zoom1 += viewmultiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.zoom1 -= viewmultiplier;
        Destroy(gameObject);
    }
}
