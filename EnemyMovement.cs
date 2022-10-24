using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField] float EnemSpeed = 1f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb.velocity = new Vector2 (EnemSpeed, 0f); 
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        EnemSpeed = -EnemSpeed;
        flipEnemFace();
    }
    void flipEnemFace()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(rb.velocity.x)),1f);
    }

}


