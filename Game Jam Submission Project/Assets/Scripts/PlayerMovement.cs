using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;
    [SerializeField] float speed;
    [SerializeField] float speedInc;//float value to tell how much to increment
    [SerializeField] float waitForIncrease;//float value to tell how long to wait before incrementing the speed
    void Start()
    {
        StartCoroutine(SpeedIncrease());
    }

    private void FixedUpdate()
    {
        controller.Move(speed * Time.fixedDeltaTime, false, false);
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
