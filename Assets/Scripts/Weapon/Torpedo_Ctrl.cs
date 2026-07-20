using System.Collections;
using UnityEngine;

public class Torpedo_Ctrl : AttackObj_Ctrl
{
    Rigidbody2D rb;

    float maxMoveDistance;

    Vector3 targetPosition;
    Vector3 currentPosition;

    Coroutine moveRoutine;

    //LayerMask layermask = LayerMask.GetMask("Water");
    public void SetTarget(Vector3 _targetPos)
    {
        targetPosition = _targetPos;
    }
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveToTarget();
    }

    //void SetCourseWithGrid()  //이건 나중에 기회되면 그리드 따라 이동하는 것으로 구현
    //{

    //}

    public void SetCourse()
    {
        currentPosition = this.transform.position;
        moveRoutine = StartCoroutine(MoveToTarget());
    }
    IEnumerator MoveToTarget()
    {
        while (true)
        {
            float moveDistance = Vector3.Distance(this.transform.position, currentPosition);

            if (moveDistance >= maxMoveDistance)
            {
                moveRoutine = null;
                yield break;
            }
            
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, 3.0f * Time.fixedDeltaTime));

            yield return new WaitForFixedUpdate();
        }
    }
    protected override IEnumerator WeaponArmed()
    {
        yield return new WaitForSeconds(2.3f);

        isArmed = true;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void DamageProtocol(GameObject obj)
    {
        if(obj.GetComponent<Player_Controller>())
        {

        }
    }
}
