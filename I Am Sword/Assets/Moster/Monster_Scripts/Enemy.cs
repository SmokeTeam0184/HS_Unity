using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int Monster_Hp; //���� ü��
    public int Monster_Exp; // ���� óġ�� ����ġ
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
