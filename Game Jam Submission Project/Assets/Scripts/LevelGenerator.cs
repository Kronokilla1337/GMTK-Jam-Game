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
    public void GeneratePreset(Vector3 endPosition)
    {
        
        int set = Random.Range(0, Presets.Length);
        float Position = Presets[set].difference + endPosition.x;
        Instantiate(Presets[set].gameObject, new Vector3(Position, 0, 0), Quaternion.identity);
    }
}
