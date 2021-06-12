using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (transform.rotation == Quaternion.identity)
            {
                transform.Rotate(0f, 0f, 45f); 
            }
            if (transform.rotation == Quaternion.Euler(0f, 0f, 45f))
            {
                transform.Rotate(0f, 0f, -45f);
            }
            if (transform.rotation == Quaternion.Euler(0f, 0f, -45f))
            {
                transform.rotation = Quaternion.identity;
            }
        }
    }
}
