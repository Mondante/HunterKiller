using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LobbyUI_Mgr : MonoBehaviour
{
    [SerializeField] Button start_Btn;
    void Start()
    {
        start_Btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
