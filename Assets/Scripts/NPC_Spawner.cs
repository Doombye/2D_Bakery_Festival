using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform pivot;
    [SerializeField] float spawnTime;
    [SerializeField] int MaxCount;

    float timer = 0;
    int count = 0;

    private void Update()
    {
        if (count > MaxCount)
            return;

        if (count < MaxCount)
        {            
            Spawn();
        }
    }

    public void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        { 
            //UI버튼이 가장 위에 보이도록 canvas 안에 NPCGroups이라는 곳 안에 생성을 함
            Instantiate(prefab, pivot.position, Quaternion.Euler(0,180,0), GameObject.Find("NpcGroups").transform);
            timer = 0;
            count++;
        }
    }
}
