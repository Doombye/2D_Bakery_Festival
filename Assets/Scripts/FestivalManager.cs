using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FestivalManager : MonoBehaviour
{
    //위 아래에서 차례대로 소환하기 위한 구분 BOOL값
    bool SpawnType = true;
    //터치 횟수에 의한 소환을 시키기위한 값
    [Header("몇번 눌러야 소환인가")]
    public float NpcSpawnCounter = 1;
 
    //현재까지 누른 터치값
    float TouchCounter = 0;
    [Header("몇명이 나와야 페스티벌인가")]
    //축제가 열리기 위한 NPC 갯수
    public float FestivalTotalCount =0f;
    [SerializeField] float FestivalCount = 0f;
    //축제중인지 알기 위한 함수
    public bool IsFestival = false;

    //축제 타이머 
    [SerializeField]float FestivalTime = 0;
    //축제때 사용하기 위한 NPC 갯수 
    float SpecialCount = 0;
    //게이지바를 채우기 위한 이미지
    [SerializeField]Image FilledImage;

    //음악 소환술식
    MusicMng Music;


    NPC_Spawner UpSpawner;
    NPC_Spawner DownSpawner;

    [SerializeField] float AutoTimer = 0.1f;

    [SerializeField] MainClickButton Mainclickbut;

    public void Start()
    {
        Music = GameObject.Find("BGMPlayer").GetComponent<MusicMng>();
        UpSpawner = GameObject.Find("NpcSpawner1").GetComponent<NPC_Spawner>();
        DownSpawner = GameObject.Find("NpcSpawner2").GetComponent<NPC_Spawner>();
        Mainclickbut = GameObject.Find("MainClickButton").GetComponent<MainClickButton>();
        StartCoroutine("AddSpawnCounter");
    }
    public void TouchFunc()
    {
        TouchCounter++;
        if (NpcSpawnCounter <= TouchCounter)
        {
            SpawnTheNpc();
        }
        Debug.Log("터치를 확인");
    }
    void SpawnTheNpc()
    {
        TouchCounter = 0;
       

        if(!IsFestival)
        {
            if (SpawnType == true)
            {
                DownSpawner.Spawn();
                FestivalCount++;  
            }
            else
            {
                UpSpawner.Spawn();
                FestivalCount++; 
            }
            
            SpawnType = !SpawnType;
        }
        
    }
    public void DeletedNpc()
    {
        FestivalCount--;

    }
    IEnumerator FestivalFunc()
    {
        yield return new WaitForSeconds(0.1f);
        FestivalTime += 0.1f;

        if (FestivalTime >= 15)
        {
            Music.DefaultSong();
            IsFestival = false;
            FestivalCount = 0; 
            FestivalTime = 0;
            Mainclickbut.IsFestivalNow = false;
            StopCoroutine("FestivalFunc");

        }
        else
        {
            StartCoroutine("FestivalFunc");
            FilledImage.fillAmount = 0; 
        } 
    }
    private void Update()
    {
        if (FestivalCount == FestivalTotalCount && IsFestival == false)
        {
            if (SpawnType == true)
            {
                DownSpawner.Spawn();
                FestivalCount++;
            }
            else
            {
                UpSpawner.Spawn();
                FestivalCount++;
            } 
            SpawnType = !SpawnType;
            IsFestival = true;
            Music.FestivalSong();
            Mainclickbut.IsFestivalNow = true; 
            SpecialCount = 0;
            StartCoroutine("FestivalFunc");
            StartCoroutine("FestivalNPCSpawn"); 
        }
        if(!IsFestival)
        {
            float Nums = 1 / NpcSpawnCounter * TouchCounter;
            FilledImage.fillAmount = Nums;
        }
        
    }
    IEnumerator FestivalNPCSpawn()
    {

        yield return new WaitForSeconds(0.1f);
        SpecialCount += 0.1f;
        if (SpecialCount >11)
        {
            StopCoroutine("FestivalNPCSpawn");
        }
        else
        {
            StartCoroutine("FestivalNPCSpawn");
            if (SpawnType == true) 
                DownSpawner.Spawn();  
            else 
                UpSpawner.Spawn();  
            SpawnType = !SpawnType;
        }
     
    }

    IEnumerator AddSpawnCounter()
    {

        yield return new WaitForSeconds(0.1f);
        AutoTimer += 0.1f;
        if(AutoTimer >= 1)
        {
            AutoTimer = 0;
            if(!IsFestival)
            TouchCounter += 2;
            if (NpcSpawnCounter <= TouchCounter)
            {
                SpawnTheNpc();
            }
            StartCoroutine("AddSpawnCounter");
        }
        else
        {
            StartCoroutine("AddSpawnCounter");
        }
    }


}

