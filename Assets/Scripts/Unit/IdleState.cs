using UnityEngine;

public class IdleState<A> : IState<A>
{
    public void Enter(A obj)
    {
        Debug.Log("Enter State");
       // throw new System.NotImplementedException();
    }

    public void Exit(A obj)
    {
        Debug.Log("Idle Exit");
    }

    public void Update(A obj)
    {
        Debug.Log("Idle");
        //throw new System.NotImplementedException();
    }
}
