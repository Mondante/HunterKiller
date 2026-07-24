using System.Collections.Generic;
using UnityEngine;

public class Stage_Manager : MonoBehaviour
{
    public static Stage_Manager instance;

    List<GameObject> enemyList = new List<GameObject>();

    List<GameObject> myAttack = new List<GameObject>();
    List<GameObject> enemyAttack = new List<GameObject>();

    bool isMyTurn = true;

    public bool IsMyTurn
    {
        get { return isMyTurn; }
    }
    int remainEnemy;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int AddMyAttack(GameObject _obj)
    {
        myAttack.Add(_obj);
        return myAttack.Count;
    }

    public void RemoveMyAttack(GameObject _obj)
    {
        myAttack.Remove(_obj);
    }

    public void AddEnemyAttack(GameObject _obj)
    {
        enemyAttack.Add(_obj);
    }

    public void RemoveEnemyAttack(GameObject _obj)
    {
        enemyAttack.Remove(_obj);
    }

    public void ChangeToEnemyTurn()
    {
        if (isMyTurn  && enemyList.Count >0)
        {
            StartCoroutine(UI_Manager.instance.RoleChange("Enemy Turn"));
            Player_Controller.instance.ChangeState(Player_Controller.instance.standbyState);
            Debug.Log("적 차례");
            isMyTurn = false;

            remainEnemy = enemyList.Count;

            for (int i = 0; i < enemyAttack.Count; i++)
            {
                MovableObj move = enemyAttack[i].GetComponent<MovableObj>();

                if (move != null)
                {
                    move.SetCourse();
                }
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                //등록되어 있는 적 유닛의 스테이트를 idle로 변경
            }
        }
        else
        {
            isMyTurn = false;
            CountEnemyTurn();
        }
    }

    public void ChangeToUserTurn()
    {
        if (!isMyTurn)
        {
            StartCoroutine(UI_Manager.instance.RoleChange("User Turn"));
            Debug.Log("userTurn");
            isMyTurn = true;
            for (int i = 0; i < myAttack.Count; i++)
            {
                MovableObj move = myAttack[i].GetComponent<MovableObj>();

                if (move != null)
                {
                    move.SetCourse();
                }
            }
            Player_Controller.instance.ChangeState(Player_Controller.instance.idleState);
        }
    }

    public void CountEnemyTurn()
    {
        if (remainEnemy > 0)
        {
            remainEnemy--;
        }
        if(remainEnemy == 0)
        {
            ChangeToUserTurn();
        }
    }
}
