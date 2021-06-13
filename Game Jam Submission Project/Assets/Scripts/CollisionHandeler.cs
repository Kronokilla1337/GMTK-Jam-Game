using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    [SerializeField] float timeOfDeathAnimation;
    PlayerMovement player;
    bool hasDied;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        hasDied = false;
    }
    private void Update()
    {
        if(transform.position.y <= -10f && !hasDied)
        {
            Death();
            hasDied = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            Death();   
        }
    }
    void Death()
    {
        //Dissolve Animation
        if (true) //animation ended
        {
            Time.timeScale = 0f;
            Destroy(this.gameObject, 5f);
            player.MoveBool(false);
            deathScreen.SetActive(true);
        }
    }
}
