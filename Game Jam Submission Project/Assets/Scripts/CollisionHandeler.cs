using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    [SerializeField] float timeOfDeathAnimation;
    [SerializeField] Material charMat;
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
            Death();
            hasDied = true;
        }
        if(hasDied)
        {
            if(fade>=0)
            {
                fade -= Time.deltaTime;
            }
        }
        charMat.SetFloat("_Fade", fade);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            Death();
            hasDied = true;
        }
    }
    void Death()
    {
        Time.timeScale = 0f;
        Destroy(this.gameObject, 6f);
        player.MoveBool(false);
        deathScreen.SetActive(true);   
    }
    
}
