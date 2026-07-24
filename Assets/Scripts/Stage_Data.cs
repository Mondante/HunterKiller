using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage_Data", menuName = "Scriptable Objects/Stage_Data")]
public class Stage_Data : ScriptableObject
{
    public string stageNum;

    public GameObject mapPrefab;

    public Vector3 playStartPos;

    public List<EnemySpawnData> enemyList = new List<EnemySpawnData>();
}
