using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField] GameObject Hamster;
    [SerializeField] GameObject Boy;
    [SerializeField] GameObject Wolf;
    [SerializeField] GameObject RedGirl;
    [SerializeField] GameObject YellowGirl;

    [SerializeField] GameObject Dragon;

    [SerializeField] GameObject Duck;
    [SerializeField] Transform pivot;


    public void Spawn()
    {
        //1부터 155까지 랜덤
        bool HaveSpawn = false;
        int RanNum = Random.Range(1, 153);
        if (RanNum <= 25 && !HaveSpawn)
        {
            Instantiate(Hamster, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);
            HaveSpawn = true;
        }
        else if (RanNum <= 50 && !HaveSpawn)
        {
            Instantiate(Boy, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);
            HaveSpawn = true;
        }

        else if (RanNum <= 75 && !HaveSpawn)
        {
            Instantiate(RedGirl, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);
            HaveSpawn = true;
        }
        else if (RanNum <= 100 && !HaveSpawn)
        {
            Instantiate(YellowGirl, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);
            HaveSpawn = true;
        }
        else if (RanNum <= 125 && !HaveSpawn)
        {
            Instantiate(Dragon, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);
            HaveSpawn = true;
        }

        else if (RanNum <= 150 && !HaveSpawn)
        {
            Instantiate(Duck, pivot.position, Quaternion.Euler(0, 180, 0), GameObject.Find("NpcGroups").transform);
            HaveSpawn = true;
        }
       
    }
}
