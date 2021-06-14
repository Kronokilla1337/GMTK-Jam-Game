using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveInc;
    [SerializeField] float upThresh;
    [SerializeField] float downThresh;
    [SerializeField] PlayerMovement player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CollisionHandeler coll;
    Vector3 dir;
    Vector2 movement;


    void Start()
    {
        Physics2D.IgnoreLayerCollision(1, 5);
    }
    void Update()
    {
        dir = player.transform.position - transform.position;
        if (dir.x >= upThresh)
            moveSpeed += moveInc;
        if (dir.x <= downThresh)
        {
            moveSpeed -= (moveInc / 2);
            moveSpeed = Mathf.Clamp(moveSpeed, 5f, moveSpeed);
        }
            
        dir.Normalize();
        movement = (Vector2)dir;
    }
    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Caught The Player");
            coll.setDeath(true);
        }
            
    }
}
