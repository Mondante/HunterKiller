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

        if(attackMode == AttackMode.Mine)
        {
            SelectAttackMethod(obj, obj.transform.position);
        }
    }

    public void Exit(Player_Controller obj)
    {
        obj.ActOnce();
    }

    public void TargetPositionSelected(Player_Controller obj, Vector3 targetPosition)
    {
        //throw new System.NotImplementedException();
        obj.readyToAct = true;
        obj.b_setPosition = false;

        //highlight.gameObject.SetActive(false);
        obj.TurnOnOffHighlight(false);
        SelectAttackMethod(obj, targetPosition);
    }

    public void Update(Player_Controller obj)
    {
        obj.MousePosition();
    }

    public void SelectAttackMethod(Player_Controller obj, Vector3 _targetPos)
    {
        switch(attackMode)
        {
            case AttackMode.Missile:
                obj.targetPosition = _targetPos;
                obj.LaunchMissile();
                break;
            case AttackMode.Torpedo:
                obj.targetPosition = _targetPos;
                obj.LaunchTorpedo();
                break;
            case AttackMode.Mine:
                obj.targetPosition = obj.transform.position;
                obj.LaunchMine();
                break;
            default:
                break;
        }

        obj.ChangeState(obj.idleState);
    }
}
