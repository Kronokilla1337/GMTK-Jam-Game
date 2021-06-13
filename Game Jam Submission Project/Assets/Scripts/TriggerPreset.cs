using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPreset : MonoBehaviour
{
    public float difference;
    [SerializeField] Transform endPosition;
    bool canTrigger;
    private void Start()
    {
        canTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && canTrigger)
        {
            LevelGenerator.Instance.GeneratePreset(endPosition.position);
            canTrigger = false;
            Destroy(this.gameObject, 40f);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
