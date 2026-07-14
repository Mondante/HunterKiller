

//using System.Numerics;

using UnityEngine;

public interface IState<A>
{
    public void Enter(A obj);

    public void Exit(A obj);

    public void Update(A obj);

    
}

public interface TargetSet<A>
{
    public void TargetPositionSelected(A obj, Vector3 targetPosition);
}

public class UnitStateMachine<A>
{
    protected IState<A> currentState;
    protected TargetSet<A> targetSet;
    
    private A obj;

    public UnitStateMachine(A _obj)
    {
        this.obj = _obj;
    }
    public void ChangeState(IState<A> state)
    {
        if (currentState != null)
        {
            currentState.Exit(obj);
        }
        currentState = state;
        targetSet = state as TargetSet<A>;
        currentState.Enter(obj);
    }

    public void IsIdle(IState<A> state)
    {
        
    }    

    public void Update()
    {
        currentState.Update(obj);
    }

    public void TargetPositionSelected(Vector3 _targetPos)
    {
        if(targetSet != null)
        {
            targetSet.TargetPositionSelected(obj, _targetPos);
        }
    }
}
