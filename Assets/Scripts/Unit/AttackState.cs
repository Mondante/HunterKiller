using UnityEngine;

public class AttackState<A> : IState<A>, TargetSet<A>
{
    public void Enter(A obj)
    {
        throw new System.NotImplementedException();
    }

    public void Exit(A obj)
    {
        throw new System.NotImplementedException();
    }

    public void TargetPositionSelected(A obj, Vector3 targetPosition)
    {
        throw new System.NotImplementedException();
    }

    public void Update(A obj)
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
