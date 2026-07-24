using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Button moveButton;
    [SerializeField] Button attackListButton;
    [SerializeField] Button[] attackBtn;
    [SerializeField] Button TurnEnd_Btn;
    [SerializeField] RawImage turnChange_Img;
    [SerializeField] TMP_Text turnChange_Txt;
    [SerializeField] Button exit_Btn;
    //public MoveState<Player_Controller> moveState;

    public static UI_Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

        exit_Btn.onClick.AddListener(() =>
        {
            Application.Quit();
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

    public IEnumerator RoleChange(string _text)
    {
        turnChange_Img.gameObject.SetActive(true);
        turnChange_Txt.text = _text;
        yield return new WaitForSeconds(2.5f);
        turnChange_Img.gameObject.SetActive(false);

    }
}
