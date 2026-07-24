using UnityEngine;

public class StandbyState : IState<Player_Controller>
{
    public void Enter(Player_Controller obj)
    {
        throw new System.NotImplementedException();
    }

    public void Exit(Player_Controller obj)
    {
        Player_Controller.instance.ActCharge();
    }

    public void Update(Player_Controller obj)
    {
        throw new System.NotImplementedException();
    }
}
