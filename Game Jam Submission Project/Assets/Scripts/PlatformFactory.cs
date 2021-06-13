using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour
{
    [SerializeField] int platformLimit = 2;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform platoformParentTransform;

    private int currentNoPlatforms = 0;

    public void AddPlatform(Waypoint waypoint)
    {
        if (currentNoPlatforms < platformLimit)
        {
            Instantiate(platformPrefab, waypoint.transform.position, Quaternion.identity, platoformParentTransform);
            currentNoPlatforms++;
            waypoint.isOccupied = true;
        }
        else
        {
            //Some error message
        }
    }

    public void DestroyPlatform(Waypoint waypoint)
    {
        foreach (Transform platform in platoformParentTransform)
        {
            if (platform.position == waypoint.transform.position)
            {
                Destroy(platform.gameObject);
                currentNoPlatforms--;
                waypoint.isOccupied = false;
                return;
            }
        }
    }

    public void DestroyPlatform(GameObject gameObject)
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (gameObject.transform.position == waypoint.transform.position)
            {
                Destroy(gameObject.gameObject);
                currentNoPlatforms--;
                waypoint.isOccupied = false;
                return;
            }
        }
    }

    public void RotatePlatform(Waypoint waypoint)
    {
        foreach (Transform platform in platoformParentTransform)
        {
            if (platform.position == waypoint.transform.position)
            {
                if (platform.rotation == Quaternion.identity)
                {
                    platform.rotation = Quaternion.Euler(Vector3.forward * 45f);
                }
                else if (platform.rotation == Quaternion.Euler(Vector3.forward * 45f))
                {
                    platform.rotation = Quaternion.Euler(Vector3.back * 45f);
                }
                else if (platform.rotation == Quaternion.Euler(Vector3.back * 45f))
                {
                    platform.rotation = Quaternion.identity;
                }
                return;
            }
        }
    }

    public void RotatePlatform(GameObject gameObject)
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (gameObject.transform.position == waypoint.transform.position)
            {
                if (gameObject.transform.rotation == Quaternion.identity)
                {
                    gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 45f);
                }
                else if (gameObject.transform.rotation == Quaternion.Euler(Vector3.forward * 45f))
                {
                    gameObject.transform.rotation = Quaternion.Euler(Vector3.back * 45f);
                }
                else if (gameObject.transform.rotation == Quaternion.Euler(Vector3.back * 45f))
                {
                    gameObject.transform.rotation = Quaternion.identity;
                }
                return;
            }
        }
    }

}
