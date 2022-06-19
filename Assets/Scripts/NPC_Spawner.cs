using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform pivot;
  
 
    public void Spawn()
    {
        Instantiate(prefab, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);

    }
}
