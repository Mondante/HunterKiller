using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

enum AttackMode
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

    public AttackState<Player_Controller> attackState;

    string currentState;

    public float moveSpeed = 10;  //움직일 수 있는 거리

    public Vector3 targetPosition;

    public bool b_setPosition = false;

    public bool readyToAct = false;

    int moveAct = 2;
    public int MoveAct
    {
        get { return moveAct; }
        private set { moveAct = value; }
    }

    int attackAct = 2;
    public int AttackAct
    {
        get { return  attackAct; }
        private set { attackAct = value; }
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

        attackState = new AttackState<Player_Controller>();

        stateMachine.ChangeState(idleState);

        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeState(IState<Player_Controller> state)
    {
        stateMachine.ChangeState(state);
    }

    // Update is called once per frame
    void Update()
    {
        //MousePosition();

        stateMachine.Update();
    }

    public void MousePosition()
    {
        if (b_setPosition )
        {
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
        }
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

    public void Move()
    {
        float distance = Vector3.Distance(this.transform.position, targetPosition);
        if(readyToAct)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, 3.0f * Time.fixedDeltaTime));
            
            if(distance == 0)
            {
                targetPosition = Vector3.zero;
                readyToAct= false;
                stateMachine.ChangeState(idleState);
            }
        }
        else
        {

        }
    }

    public void TurnOnOffHighlight(bool set)
    {
        highlight.gameObject.SetActive(set);
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

    public void Attack()
    {

    }

    //bool CheckState()
    //{
    //    //return stateMachine.IsIdle(idleState)
    //}

    
}
