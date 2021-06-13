using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPreset : MonoBehaviour
{
    public float difference;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            LevelGenerator.Instance.GeneratePreset(transform.position);
            Destroy(this.gameObject, 40f);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
