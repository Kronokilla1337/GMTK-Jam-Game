using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [HideInInspector] public bool isOccupied = false;

    private PlatformFactory platformFactory;

    private void Start()
    {
        platformFactory = FindObjectOfType<PlatformFactory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isOccupied)
            {
                platformFactory.AddPlatform(this);
            }
            else
            {
                platformFactory.DestroyPlatform(this);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isOccupied)
        {
            platformFactory.RotatePlatform(this);
        }
    }

}
