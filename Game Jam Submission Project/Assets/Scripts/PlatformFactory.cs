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
            Instantiate (platformPrefab, waypoint.transform.position + Vector3.back, Quaternion.identity, platoformParentTransform);
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
            if (platform.position + Vector3.forward == waypoint.transform.position)
            {
                Destroy(platform.gameObject);
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
            if (platform.position + Vector3.forward == waypoint.transform.position)
            {
                if (platform.transform.rotation == Quaternion.identity)
                {
                    platform.transform.rotation = Quaternion.Euler(Vector3.forward * 45f);
                }
                else if (platform.transform.rotation == Quaternion.Euler(Vector3.forward * 45f))
                {
                    platform.transform.rotation = Quaternion.Euler(Vector3.back * 45f);
                }
                else if (platform.transform.rotation == Quaternion.Euler(Vector3.back * 45f))
                {
                    platform.transform.rotation = Quaternion.identity;
                }
                return;
            }
        }
    }

}
