using NUnit.Framework;
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

    [SerializeField] UnityEngine.Grid grid;

    [SerializeField] LayerMask layerMask;

    [SerializeField] GameObject highlight;

    public UnitStateMachine<Player_Controller> stateMachine;

    public IdleState<Player_Controller> idleState;

    public MoveState<Player_Controller> moveState;
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

        moveState = new MoveState<Player_Controller>();

        stateMachine.ChangeState(idleState);
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

            highlight.gameObject.SetActive(true);
            highlight.transform.position = previewPosition;
            //Debug.Log(previewPosition);
        }
        else
        {
            highlight.gameObject.SetActive(false);
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
}
