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
<<<<<<< Updated upstream
            Death();   
=======
            Death()   
>>>>>>> Stashed changes
        }
    }
    void Death()
    {
        //Dissolve Animation
        if (true) //animation ended
        {
            Time.timeScale = 0f;
<<<<<<< Updated upstream
            Destroy(this.gameObject, 5f);
=======
>>>>>>> Stashed changes
            player.MoveBool(false);
            deathScreen.SetActive(true);
        }
    }
}
