using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformFactory platformFactory;

    void Start()
    {
        platformFactory = FindObjectOfType<PlatformFactory>();
    }

    private void OnMouseOver()
    {
        Debug.Log("Called");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            platformFactory.DestroyPlatform(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            platformFactory.RotatePlatform(gameObject);
        }
    }

}
