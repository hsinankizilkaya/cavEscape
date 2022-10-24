using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D rb1;
    PlayerMovement player1;
    float xSpeed;
    GameObject Enem;
    

    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
        player1 = FindObjectOfType<PlayerMovement>();
        xSpeed = player1.transform.localScale.x * bulletSpeed;
        Enem = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {
        rb1.velocity = new Vector2 (xSpeed,0f);
    }

    
    void OnCollisionEnter2D(Collision2D other)  
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            FindObjectOfType<EnemDie>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(GameObject.FindWithTag("Bullet"));
    }
        
}
