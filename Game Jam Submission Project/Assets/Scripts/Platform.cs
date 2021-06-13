using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [HideInInspector] public Waypoint baseWaypoint;

    private PlatformFactory platformFactory;

    void Start()
    {
        platformFactory = FindObjectOfType<PlatformFactory>();
    }

    private void OnMouseOver()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            platformFactory.DestroyPlatform(baseWaypoint, this);
            baseWaypoint.isOccupied = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            platformFactory.RotatePlatform(baseWaypoint, this);
        }
    }

    private void OnBecameInvisible()
    {
        if(gameObject.activeSelf)
        {
            platformFactory.DestroyPlatform(baseWaypoint, this);
        }
    }

}
