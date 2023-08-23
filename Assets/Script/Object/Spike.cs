using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag=="Player")
        {
            PlayerDeath playerdeath = collision.gameObject.GetComponent<PlayerDeath>();
            playerdeath.Death();
        }
    }
}
