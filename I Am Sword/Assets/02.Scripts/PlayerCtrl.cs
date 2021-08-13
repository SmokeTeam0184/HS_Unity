using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 10; // 캐릭터 속도

    public int health = 30; //기본 체력
    public int shield = 20; //기본 쉴드
    public int Item_Crystal = 0;

    public int[] MaxHealth = { 30, 40, 50 }; //최대체력
    public int[] MaxShield = { 20, 30, 40 }; //최대쉴드

    float hAxis; //좌우 
    float vAxis; //전진 후진

    Animator anim;

    Rigidbody playerRb;

    Vector3 moveVec;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        GetInput();
        Move();
        Turn();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        transform.position += moveVec = new Vector3(hAxis, 0, vAxis).normalized * speed * Time.deltaTime;

        anim.SetBool("isMove", moveVec != Vector3.zero);
    }


    void Turn()
    {
        transform.LookAt(transform.position + moveVec);

    }

    void Attack()
    {
        if (Input.GetKeyDown("Fire1"))
        {
            //anim.
        }
    }
}
