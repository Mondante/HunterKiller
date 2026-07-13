using UnityEngine;

public class MoveState<A> : IState<A>
{
    public void Enter(A obj)
    {
        Debug.Log("Move Enter");
    }

    public void Exit(A obj)
    {
        throw new System.NotImplementedException();
    }

    public void Update(A obj)
    {
        Player_Controller.instance.MousePosition();
    }
}
