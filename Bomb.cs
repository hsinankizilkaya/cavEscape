using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D myBodyCollider;
    SpriteRenderer mySprite;

    [SerializeField] AudioClip myBombSfx;

    void Start()
    {
        myBodyCollider = GetComponent<CircleCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.tag == "Player")
       {
        mySprite.enabled = false;
        AudioSource.PlayClipAtPoint(myBombSfx, Camera.main.transform.position);
       } 
           
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(GameObject.FindWithTag("Bomb"));
    }     
    
    
        
    
}
