using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;
    [SerializeField] float speed;
    [SerializeField] float speedInc;//float value to tell how much to increment
    [SerializeField] float waitForIncrease;//float value to tell how long to wait before incrementing the speed
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float gravityScale;
    public bool canMove;
    void Start()
    {
        canMove = true;
        StartCoroutine(SpeedIncrease());
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            controller.Move(speed * Time.fixedDeltaTime, false, false);
        }
            
        if(controller.IsGrounded())
        {
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
    }
    public void MoveBool(bool can)
    {
        canMove = can;
    }
    IEnumerator SpeedIncrease()
    {
        int i = 1;
        while(true)//Has to change to while player is alive
        {
            speed += speedInc;
            speed = Mathf.Clamp(speed, 10f, 125f);
            if (speed % 50 == 0)
            {
                gravityScale += (10*i);
                i++;
            }
            yield return new WaitForSeconds(waitForIncrease);
        }
    }
    
}
