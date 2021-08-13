using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    public int ATK = 5; // 공격력

    //float ATKSP = 0.34f; //공격속도

    int[] requireExp = { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 }; //레벨당 무기 경험치

    public int currExp; //현재 경험치
    public int currLevel; //아이템 레벨
    public string WpRating;

    int[] RatingLv = { 11, 21, 31 };


    void Start()
    {
        currExp = 0;
        currLevel = 1;
        WpRating = "노멀";
        
        
    }

    public void getEXP(int _exp)
    {
        currExp += _exp;
        if (currExp >= getRequireExp(currLevel))
        {
            LevelUP();
        }

    }

    void LevelUP()
    {
        print("레벨 업!!");
        currLevel++;
        ATK += 2;
        currExp = 0;
    }

    void RatingUP()
    {

        if(currLevel <= 11)
        {
            print("등급 업!!");
        }

    }

    int getRequireExp(int _level)
    {
        return requireExp[_level - 1];
    }
}
