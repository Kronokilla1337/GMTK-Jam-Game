using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class PlatformFactory : MonoBehaviour
{
    [SerializeField] Platform platformPrefab;
    [SerializeField] Transform platoformParentTransform;
    [SerializeField] TMP_Text inventoryText;
    [SerializeField] AudioClip WallPlacementSFX;
    [SerializeField] AudioClip WallDestroySFX;
    [SerializeField] AudioClip WallRotateSFX;

    private const int platformLimit = 2;
    private int currentNoPlatforms = 0;

    private void UpdateInventoryText()
    {
        inventoryText.text = (platformLimit - currentNoPlatforms).ToString();
    }

    public void AddPlatform(Waypoint waypoint)
    {
        if (currentNoPlatforms < platformLimit)
        {
            Instantiate(platformPrefab, waypoint.transform.position, Quaternion.identity, platoformParentTransform).baseWaypoint = waypoint;
            currentNoPlatforms++;
            UpdateInventoryText();
            waypoint.isOccupied = true;
            AudioSource.PlayClipAtPoint(WallPlacementSFX, Vector3.zero);
        }
        else
        {
            Debug.Log("Error Message");
        }
    }

    private Platform FindPlatform(Waypoint waypoint, Platform platform)
    {
        foreach (Transform transform in platoformParentTransform)
        {
            if (transform.position == waypoint.transform.position)
            {
                platform = transform.GetComponent<Platform>();
            }
        }
        return platform;
    }

    public void DestroyPlatform(Waypoint waypoint, Platform platform = null)
    {
        if (platform == null)
        {
            platform = FindPlatform(waypoint, platform);
        }
        Destroy(platform.gameObject);
        currentNoPlatforms--;
        UpdateInventoryText();
        waypoint.isOccupied = false;
        AudioSource.PlayClipAtPoint(WallDestroySFX, Vector3.zero);

    }

    public void RotatePlatform(Waypoint waypoint, Platform platform = null)
    {
        if (platform == null)
        {
            platform = FindPlatform(waypoint, platform);
        }
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
        AudioSource.PlayClipAtPoint(WallRotateSFX, Vector3.zero);
    }
}
