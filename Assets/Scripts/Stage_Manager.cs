using System.Collections.Generic;
using UnityEngine;

public class Stage_Manager : MonoBehaviour
{
    public static Stage_Manager instance;

    List<GameObject> enemyList;

    List<GameObject> myAttack = new List<GameObject>();
    List<GameObject> enemyAttack = new List<GameObject>();
    void Start()
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

    public void RemoveMyAttack(int _number)
    {
        myAttack.RemoveAt(_number);
    }

    public void ChangeToEnemyTurn()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            //등록되어 있는 적 유닛의 스테이트를 idle로 변경
        }
    }

    public void ChangeToUserTurn()
    {
        Player_Controller.instance.ChangeState(Player_Controller.instance.idleState);
    }
}
