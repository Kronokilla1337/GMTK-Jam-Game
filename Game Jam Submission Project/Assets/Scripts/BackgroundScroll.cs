using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    float textureUnitSize;
    Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSize = texture.width / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        if (cameraTransform.position.x - transform.position.x >= 30)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSize;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y, 10);
        }
    }
}
