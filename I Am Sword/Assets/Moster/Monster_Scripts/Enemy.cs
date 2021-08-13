using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int Monster_Hp; //몬스터 체력
    public int Monster_Exp; // 몬스터 처치시 경험치
    public GameObject Item;
    
    public bool isDead;

    private void Update()
    {
        Test();

    }
    public void Test()
    {
        for (int i = 0; i < 5; i++)
        {

            if (Monster_Hp < 5)
            {
                Destroy(this.gameObject, 0.5f);

            }
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }
}
