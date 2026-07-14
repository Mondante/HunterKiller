using UnityEngine;

public class MoveState<A> : IState<A>
{
    Rigidbody2D rb;
    
    public void Enter(A obj)
    {
        Debug.Log("Move Enter");
        //StartCoroutine(Player_Controller.instance.MousePosition());

        Player_Controller.instance.b_setPosition = true;
        
    }

    public void Exit(A obj)
    {
        Debug.Log(Player_Controller.instance.moveSpeed);
    }

    public void Update(A obj)
    {
        Player_Controller.instance.MousePosition();
        Player_Controller.instance.Move();
        //마우스 클릭 시 플레이어를 움직인다.
    }
}
