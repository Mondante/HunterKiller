using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Button moveButton;
    [SerializeField] Button attackListButton;

    public MoveState<Player_Controller> moveState;
    void Start()
    {
        moveState = new MoveState<Player_Controller>();
        moveButton.onClick.AddListener(() => 
        {
            Player_Controller.instance.ChangeState(moveState);
        });
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
