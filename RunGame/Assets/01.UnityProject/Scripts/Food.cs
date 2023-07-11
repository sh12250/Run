using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int expiration;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < expiration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameManager.instance.AddScore(100);

            Destroy(gameObject);
        }
    }
}
