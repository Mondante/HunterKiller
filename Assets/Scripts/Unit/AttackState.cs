using UnityEngine;

enum AttackMethod
{
    Missile,
    Torpedo
}
public class AttackState : IState<Player_Controller>, TargetSet<Player_Controller>
{
    public void Enter(Player_Controller obj)
    {
        Debug.Log("AttackState");
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
        
    }
}
