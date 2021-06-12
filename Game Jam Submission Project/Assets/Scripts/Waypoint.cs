using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [HideInInspector] public bool isOccupied = false;

    private PlatformFactory platoformFactory;

    private void Start()
    {
        platoformFactory = FindObjectOfType<PlatformFactory>();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isOccupied)
            {
                platoformFactory.AddPlatform(this);
            }
            else
            {
                platoformFactory.DestroyPlatform(this);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isOccupied)
        {
            platoformFactory.RotatePlatform(this);
        }
    }

}
