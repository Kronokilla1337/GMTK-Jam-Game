using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    [SerializeField] float timeOfDeathAnimation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            //Dissolve Animation
            if (true) //animation ended
            {
                Time.timeScale = 0f;
                deathScreen.SetActive(true);
            }
        }
    }
}
