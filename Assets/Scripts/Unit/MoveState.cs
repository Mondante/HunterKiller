using UnityEngine;

public class MoveState : IState<Player_Controller>, TargetSet<Player_Controller>
{
    Rigidbody2D rb;

    //private A obj;
    //public MoveState(A _obj)
    //{
    //    this.obj = _obj;
    //}
    public void Enter(Player_Controller obj)
    {
        Debug.Log("Move Enter");
        //StartCoroutine(Player_Controller.instance.MousePosition());

        obj.b_setPosition = true;
        
    }

    public void Exit(Player_Controller obj)
    {
        Debug.Log(Player_Controller.instance.moveSpeed);
    }

    public void TargetPositionSelected(Player_Controller obj, Vector3 _targetPosition)
    {
        //targetPosition = previewPosition;
        float distance = Vector3.Distance(obj.transform.position, _targetPosition);

        if (obj.DistanceCheck(distance))
        {
            obj.readyToAct = true;
            obj.b_setPosition = false;

            //highlight.gameObject.SetActive(false);
            obj.TurnOnOffHighlight(false);

            obj.moveSpeed -= distance;
            if (obj.moveSpeed < 1 && obj.moveSpeed > 0)
            {
                obj.moveSpeed = 0;
            }
            obj.targetPosition = _targetPosition;
        }
    }

    public void Update(Player_Controller obj)
    {
        Player_Controller.instance.MousePosition();
        Player_Controller.instance.Move();
        //마우스 클릭 시 플레이어를 움직인다.
    }
}
