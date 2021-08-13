using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public float spawnTime = 2f;
    public float curTime;
    //public GameObject item;  //몬스터 처치시 획득 아이템

    public Transform[] spawnPoints;
    public GameObject[] enemy;
    // Update is called once per frame
    void Update()
    {
        if(curTime >= spawnTime)
        {
            int x = Random.Range(0, spawnPoints.Length);
            SpawnEnemy(x);
            //Instantiate(item, transform.position, Quaternion.identity);

        }
        curTime += Time.deltaTime;
        
    }

    public void SpawnEnemy(int x)
    {
        curTime = 0;
        Instantiate(enemy[0], spawnPoints[x]);
    }


    public void DeleteEnemy()
    {
       
    }
}
