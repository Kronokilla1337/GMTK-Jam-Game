using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour
{
    [SerializeField] int platformLimit = 2;
    [SerializeField] Platform platformPrefab;
    [SerializeField] Transform platoformParentTransform;

    private int currentNoPlatforms = 0;

    public void AddPlatform(Waypoint waypoint)
    {
        if (currentNoPlatforms < platformLimit)
        {
            Instantiate (platformPrefab, waypoint.transform.position, Quaternion.identity, platoformParentTransform);
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
                Destroy(platform);
                currentNoPlatforms--;
                waypoint.isOccupied = false;
                return;
            }
        }
    }

}
