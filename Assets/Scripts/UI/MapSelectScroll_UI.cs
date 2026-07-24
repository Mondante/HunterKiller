using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class MapSelectScroll_UI : MonoBehaviour
{
    [Header("Scroll View")]
    [SerializeField] Transform content;

    [Header("Btn Prefab")]
    [SerializeField] Button button;

    List<string> map_List = new List<string>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBtn()
    {
        map_List.Clear();

        foreach(Transform child in content)
        {

        }
    }
}
