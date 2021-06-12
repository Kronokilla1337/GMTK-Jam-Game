using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;
    [SerializeField] float speed;
    [SerializeField] float speedInc;//float value to tell how much to increment
    [SerializeField] float waitForIncrease;//float value to tell how long to wait before incrementing the speed
    public bool canMove;
    void Start()
    {
        canMove = true;
        StartCoroutine(SpeedIncrease());
    }

    private void FixedUpdate()
    {
        if(canMove)
            controller.Move(speed * Time.fixedDeltaTime, false, false);
    }
    public void MoveBool(bool can)
    {
        canMove = can;
    }
    IEnumerator SpeedIncrease()
    {
        while(true)//Has to change to while player is alive
        {
            speed += speedInc;
            yield return new WaitForSeconds(waitForIncrease);
        }
    }
    
}
