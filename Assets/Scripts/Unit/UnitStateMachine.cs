
using System.Security.Cryptography;

public interface IState<A>
{
    public void Enter(A obj);

    public void Exit(A obj);

    public void Update(A obj);
}

public class UnitStateMachine<A>
{
    protected IState<A> currentState;

    private A obj;

    public void ChangeState(IState<A> state)
    {
        currentState.Exit(obj);
        currentState = state;
        currentState.Enter(obj);
    }

    public void Update()
    {
        currentState.Update(obj);
    }


}
