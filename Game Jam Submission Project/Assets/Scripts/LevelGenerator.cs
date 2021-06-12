using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField] GameObject[] Presets;
    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        
    }
    public void GeneratePreset(Vector3 Position, float space)
    {
        Position.x += space;
        int set = Random.Range(0, Presets.Length);
        Instantiate(Presets[set], Position, Quaternion.identity);
    }
}
