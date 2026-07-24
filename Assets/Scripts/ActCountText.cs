using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActCountText : MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    

    public static ActCountText instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //countText = GetComponent<TMP_Text>();

        Debug.Log("text");
        //UpdateText(Player_Controller.instance.ActCount);
    }

    public void UpdateText(int _num)
    {
        countText.text = ($"Action : {_num}");
    }
}
