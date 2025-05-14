using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;
    void Start()
    {
        playerCollector = GetComponent<CircleCollider2D>();
        player = FindAnyObjectByType<PlayerStats>();
    }

    void Update()
    {
        playerCollector.radius = player.currentMagnet;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Check if the other game object has the ICollectible interface
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 foreceDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(foreceDirection * pullSpeed);
            
            //If it does, call the Collect method
            collectible.Collect();
        }
    }
}