using System.Collections;
using UnityEngine;

public class Torpedo_Ctrl : AttackObj_Ctrl, MovableObj
{
    Rigidbody2D rb;

    float maxMoveDistance = 5f;

    
    Vector3 currentPosition;

    Coroutine moveRoutine;


    //LayerMask layermask = LayerMask.GetMask("Water");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    public IEnumerator MoveToTarget()
    {
        while (true)
        {
            float moveDistance = Vector3.Distance(this.transform.position, currentPosition);

            Vector2 dir = (targetPosition - currentPosition).normalized;
 
         

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            //rb.rotation = angle - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle-90);
     
            //this.transform.rotation = Quaternion.LookRotation(dir);

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
        if (obj.CompareTag("Unit") || obj.CompareTag("Weapon"))
        {
            Debug.Log("Damaged");
            Unit_Controller ctrl = obj.GetComponent<Unit_Controller>();
            if (ctrl != null)
            {
                Debug.Log($"Damage :{damage}");
                ctrl.TakeDamage(damage);
            }
            else
            {
                Debug.Log("No ctrl");
            }
        }
    }

    public override void SetState(Vector3 _pos, int _atckOrder, int _damage)
    {
        targetPosition = _pos;
        atckOrder = _atckOrder;
        damage = _damage;
        StartCoroutine(WeaponArmed());
    }
}
