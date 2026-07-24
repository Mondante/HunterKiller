using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Button moveButton;
    [SerializeField] Button attackListButton;
    [SerializeField] Button[] attackBtn;
    [SerializeField] Button TurnEnd_Btn;
    //public MoveState<Player_Controller> moveState;
    void Start()
    {
        //moveState = new MoveState<Player_Controller>();
        moveButton.onClick.AddListener(() =>
        {
            if (Player_Controller.instance.stateMachine.CurrentState == Player_Controller.instance.idleState)
            {
                Player_Controller.instance.ChangeState(Player_Controller.instance.moveState);
            }
        });

        attackListButton.onClick.AddListener(() =>
        {
            //for (int i = 0; i < attackBtn.Length; i++)
            //{
            //    attackBtn[i].gameObject.SetActive(!attackBtn[i].gameObject.activeSelf);
            //}
            AtckBtnAble();
        });

        for (int i = 0; i < attackBtn.Length; i++)
        {
            int index = i;
            attackBtn[index].onClick.AddListener(() =>
            {
                if (Player_Controller.instance.stateMachine.CurrentState == Player_Controller.instance.idleState)
                {
                    AtckBtnClicked(index);
                }
            });
        }

        TurnEnd_Btn.onClick.AddListener(() =>
        {
            if (Player_Controller.instance.stateMachine.CurrentState == Player_Controller.instance.idleState)
            {
                Stage_Manager.instance.ChangeToEnemyTurn();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AtckBtnAble()
    {
        for (int i = 0; i < attackBtn.Length; i++)
        {
            attackBtn[i].gameObject.SetActive(!attackBtn[i].gameObject.activeSelf);
        }
    }
    void AtckBtnClicked(int i)
    {
        switch(i)
        {
            case 0:
                Player_Controller.instance.attackMode = AttackMode.Missile;
                Player_Controller.instance.ChangeState(Player_Controller.instance.attackState);
                break;
            case 1:
                Player_Controller.instance.attackMode = AttackMode.Torpedo;
                Player_Controller.instance.ChangeState(Player_Controller.instance.attackState);
                break;
            case 2:
                Player_Controller.instance.attackMode = AttackMode.Mine;
                Player_Controller.instance.ChangeState(Player_Controller.instance.attackState);
                break;
        }
    }
}
