using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Game_Mgr : MonoBehaviour
{
    public static Game_Mgr instance;

    List<string> map_List = new List<string>();
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
        DontDestroyOnLoad(this);
    }


    void Update()
    {
        
    }

}
