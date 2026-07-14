using System.Collections.Generic;
using UnityEngine;

public class Stage_Manager : MonoBehaviour
{
    public static Stage_Manager instance;

    List<GameObject> enemyList; 
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


    public void ChangeToEnemyTurn()
    {
        
    }

    public void ChangeToUserTurn()
    {

    }
}
