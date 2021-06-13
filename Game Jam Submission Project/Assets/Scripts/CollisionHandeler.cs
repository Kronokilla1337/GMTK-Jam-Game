using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    [SerializeField] float timeOfDeathAnimation;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Material charMat;
    [SerializeField] ScoreSystem scoreSystem;
    public float fade=1f;
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
            hasDied = true;

        }
        if(hasDied)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (fade>=0)
            {
                fade -= Time.deltaTime*0.5f;
            }
            if(fade<=0)
            {
                Death();
            }    
        }
        charMat.SetFloat("_Fade", fade);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            hasDied = true;
        }
    }
    void Death()
    {
        if(hasDied)
        {
            Destroy(this.gameObject, 6f);
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            scoreSystem.ChangeScoreOnEndScreen();
        }
    }
    
}
