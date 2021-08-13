using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    int[] requireExp = { 250, 500, 1000, 2000 };

    public int currExp; //현재 경험치
    public int currLevel; //아이템 레벨
    string itemClass;
    


    // Start is called before the first frame update
    void Start()
    {
        currExp = 0;
        currLevel = 1; //초기레벨 설정
        itemClass = "일반";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //경험치 획득
    public void getEXP(int _exp)
    {
        currExp += _exp;
        if(currExp >= getRequireExp(currLevel))
        {
            LevelUP();
        }
    }

    void LevelUP()
    {
        //레벨 업
        print("레벨 업!!!!!!!!!!!!!!!!!!!!");
        //
        currLevel++;
        currExp = 0;
    }

    int getRequireExp(int _level)
    {
        return requireExp[_level - 1];
    }
}
