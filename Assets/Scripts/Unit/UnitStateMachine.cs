

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
        currentState.Enter(obj);
    }

    public void Update()
    {
        currentState.Update(obj);
    }
}
