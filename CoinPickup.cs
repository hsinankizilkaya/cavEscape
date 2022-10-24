using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip myCoinSfx;
    [SerializeField] int pointsToAdd = 1;
    
    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsToAdd);
            AudioSource.PlayClipAtPoint(myCoinSfx, Camera.main.transform.position);
            Destroy(gameObject);
        }
        
    }
        
}