using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField] TriggerPreset[] Presets;
    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        
    }
    public void GeneratePreset(Vector3 Position)
    {
        
        int set = Random.Range(0, Presets.Length);
        Position.x += Presets[set].difference;
        Instantiate(Presets[set].gameObject, Position, Quaternion.identity);
    }
}
