using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AttackMode
{
    Idle,
    Torpedo,
    Missile,
    Mine
}
public class Player_Controller : MonoBehaviour
{
    public static Player_Controller instance;

    Camera camera;

    Rigidbody2D rb;

    [SerializeField] UnityEngine.Grid grid;

    [SerializeField] LayerMask layerMask;

    [SerializeField] GameObject highlight;

    public UnitStateMachine<Player_Controller> stateMachine;

    public IdleState<Player_Controller> idleState;

    public MoveState moveState;

    public AttackState attackState;

    public StandbyState standbyState;

    public float moveSpeed = 10;  //움직일 수 있는 거리

    public Vector3 targetPosition;

    public bool b_setPosition = false;

    public bool readyToAct = false;

    int actCount = 4;

    public AttackMode attackMode;
    public int ActCount
    {
        get { return actCount; }
        private set { actCount = value; }
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        camera = Camera.main;

        stateMachine = new UnitStateMachine<Player_Controller>(this);

        idleState = new IdleState<Player_Controller>();

        moveState = new MoveState();

        attackState = new AttackState();

        standbyState = new StandbyState();
        //attackState = new AttackState<Player_Controller>();

        stateMachine.ChangeState(idleState);

        rb = GetComponent<Rigidbody2D>();

        ActCountText.instance.UpdateText(actCount);
    }
    
    void Update()
    {
        //MousePosition();

        stateMachine.Update();
    }

    /// <summary>
    /// 스테이트 관련 체크 등
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(IState<Player_Controller> state)
    {
        if (ActCount > 0)
        {
            stateMachine.ChangeState(state);
        }
        else
        {
            //UI로 만들어라잉
            Debug.Log("행동 횟수 끝");
        }
    }

    public void ActCharge()
    {
        actCount = 4;
        ActCountText.instance.UpdateText(actCount);
    }
    public void ActOnce()
    {
        ActCount--;
        ActCountText.instance.UpdateText(actCount);
    }

    public void MousePosition()
    {
        //if (b_setPosition )
        //{
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            //Debug.Log("world"+ worldPos);

            //Vector3 selectedPosition = GetSelectedMapPosition

            //Vector3Int cell = grid.WorldToCell(worldPos);


            //Vector3 selPos = GetSelctedMapPosition(new Vector3(mousePos.x, mousePos.y, 0));

            if (GetSelctedMapPosition(new Vector3(mousePos.x, mousePos.y, 0), out Vector3 selPos))
            {

                Vector3Int cell = grid.WorldToCell(selPos);
                Vector3 previewPosition = grid.GetCellCenterWorld(cell);

                //highlight.gameObject.SetActive(true);
                TurnOnOffHighlight(true);
                highlight.transform.position = previewPosition;
                //Debug.Log(previewPosition);

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    Debug.Log("클릭까지 성공");
                    stateMachine.TargetPositionSelected(previewPosition);
                    //targetPosition = previewPosition;
                    //float distance = Vector3.Distance(this.transform.position, targetPosition);

                    //if (DistanceCheck(distance))
                    //{
                    //    readyToAct = true;
                    //    b_setPosition = false;

                    //    highlight.gameObject.SetActive(false);

                    //    moveSpeed -= distance;
                    //    if(moveSpeed < 1 && moveSpeed > 0)
                    //    {
                    //        moveSpeed = 0;
                    //    }
                    //}
                }
            }
            else
            {
                //highlight.gameObject.SetActive(false);
                TurnOnOffHighlight(false);
            }
        //}
    }
    

    bool GetSelctedMapPosition(Vector3 mousePosition, out Vector3 selectedPoint)
    {
        //Vector3 selectedPoint = Vector3.zero;
        //mousePosition.z = camera.nearClipPlane;
        Ray ray = camera.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 1000f, layerMask);

        
        //if (Physics.Raycast(ray, out hit, 1000, layerMask))
        //{
        //    Debug.Log(hit.collider.gameObject.name);
        //    selectedPoint = hit.point;
        //}
        
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            selectedPoint = hit.point;
            return true;
        }

        selectedPoint = Vector3.zero;
        return false;
    }

    public void TurnOnOffHighlight(bool set)
    {
        highlight.gameObject.SetActive(set);
    }

    /// <summary>
    /// 이동
    /// </summary>

    //public void Move()
    //{
    //    float distance = Vector3.Distance(this.transform.position, targetPosition);
    //    if(readyToAct/* && actCount > 0*/)
    //    {
    //        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, 3.0f * Time.fixedDeltaTime));
            
    //        if(distance == 0)
    //        {
    //            targetPosition = Vector3.zero;
    //            readyToAct= false;
    //            stateMachine.ChangeState(idleState);
    //        }
    //    }
    //    else
    //    {

    //    }
    //}

    public void StartMove()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        float distance = Vector3.Distance(this.transform.position, targetPosition);

        //회전
        Vector2 dir = (targetPosition - this.transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);


        //이동
        while (Vector2.Distance(this.transform.position, targetPosition) > 0)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, 3.0f * Time.fixedDeltaTime));

            yield return new WaitForFixedUpdate();
        }

        targetPosition = Vector3.zero;
        stateMachine.ChangeState(idleState);
    }
    public bool DistanceCheck(float distance)
    {       
        //RaycastHit2D hit;

        if (distance <= moveSpeed && distance != 0/*&& Physics.Raycast(this.transform.position, targetPosition, distance, ~LayerMask.GetMask("Land"))*/)
        {
            return true;
        }
        else 
        {

            return false;
        } 
    }


    /// <summary>
    /// 공격
    /// </summary>


    public void LaunchMissile()
    {
        Debug.Log("Missile launch");
        GameObject missile = ObjectPool_Mgr.instance.GetObject("Missile");
        missile.transform.position = this.transform.position; //Fire 위치 정하던가 유지하던가
        missile.GetComponent<Missile_Ctrl>().SetState(targetPosition, 0, 10);
        Stage_Manager.instance.AddMyAttack(missile);
        missile.GetComponent<Missile_Ctrl>().SetCourse();

    }

    public void LaunchTorpedo()
    {
        Debug.Log("Torpedo Launch");
        GameObject torpedo = ObjectPool_Mgr.instance.GetObject("Torpedo");
        torpedo.transform.position = this.transform.position;
        torpedo.GetComponent<Torpedo_Ctrl>().SetState(targetPosition, 0, 20);
        Stage_Manager.instance.AddMyAttack(torpedo);
        torpedo.GetComponent<Torpedo_Ctrl>().SetCourse();

    }

    public void LaunchMine()
    {
        Debug.Log("Mine Launch");
        GameObject mine = ObjectPool_Mgr.instance.GetObject("Mine");
        mine.transform.position = this.transform.position;
        //mine.GetComponent<Mine_Ctrl>().SetState();
        
    }
    

    ///
    public void TakeDamage()
    {

    }
}
