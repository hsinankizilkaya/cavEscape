using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    Animator myAnim;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

   void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        myAnim.SetTrigger("Explo");
    }
}
