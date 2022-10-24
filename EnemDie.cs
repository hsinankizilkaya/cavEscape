using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDie : MonoBehaviour
{
    [SerializeField] AudioClip enemDieVoice; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") 
        {
            
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(enemDieVoice, Camera.main.transform.position);
        }
    }
    
    
}
