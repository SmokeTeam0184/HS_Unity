using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   public enum State
    {
        PATROL, //순찰
        TRACE, //추적
        ATTACK, //공격
        DIE //사망
    }

    public State state = State.PATROL; //초기상태 지정

    Transform playerTr; //플레이어 위치 저장 
    Transform enemyTr;

    public float attackDist = 5f; //공격 사거리
    public float traceDist = 10f; //추적 사거리
    public bool isDie = false; //사망여부 판단

    WaitForSeconds ws; // 시간지연변수

    //무브에이전트
    // 적 공격

    Animator animator;

    //애니메이션--------------------------------------------
    readonly int hashMove = Animator.StringToHash("Run");



}
