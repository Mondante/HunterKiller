using UnityEngine;

enum AttackMethod
{
    Missile,
    Torpedo,
    Mine
}
public class AttackState : IState<Player_Controller>, TargetSet<Player_Controller>
{
    AttackMode attackMode;
    public void Enter(Player_Controller obj)
    {
        Debug.Log("AttackState");
        attackMode = obj.attackMode;
    }

    public void Exit(Player_Controller obj)
    {
        obj.ActOnce();
    }

    public void TargetPositionSelected(Player_Controller obj, Vector3 targetPosition)
    {
        //throw new System.NotImplementedException();

        SelectAttackMethod();
    }

    public void Update(Player_Controller obj)
    {
        obj.MousePosition();
    }

    public void SelectAttackMethod()
    {
        switch(attackMode)
        {
            case AttackMode.Missile:
                break;
            case AttackMode.Torpedo:
                break;
            case AttackMode.Mine:
                break;
            default:
                break;
        }
    }
}
