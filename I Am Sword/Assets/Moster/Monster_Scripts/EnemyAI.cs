using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   public enum State
    {
        PATROL, //����
        TRACE, //����
        ATTACK, //����
        DIE //���
    }

    public State state = State.PATROL; //�ʱ���� ����

    Transform playerTr; //�÷��̾� ��ġ ���� 
    Transform enemyTr;

    public float attackDist = 5f; //���� ��Ÿ�
    public float traceDist = 10f; //���� ��Ÿ�
    public bool isDie = false; //������� �Ǵ�

    WaitForSeconds ws; // �ð���������

    //���꿡����Ʈ
    // �� ����

    Animator animator;

    //�ִϸ��̼�--------------------------------------------
    readonly int hashMove = Animator.StringToHash("Run");



}
