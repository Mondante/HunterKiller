using System.Collections;
using UnityEngine;

public class Missile_Ctrl : AttackObj_Ctrl, MovableObj
{
    Collider2D col;

    int armedTimer = 1;

    Vector3 targetPos;

    int arriveTime;


    protected override void DamageProtocol(GameObject obj)
    {
        //폭발 시 구역 내 데미지 구현
    }

    protected override IEnumerator WeaponArmed()
    {
        if (col.isActiveAndEnabled)
        {
            col.enabled = false;
        }
        yield return armedTimer--;
    }

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    protected override void Start()
    {
        base.Start();

        //col = this.GetComponent<Collider2D>();

        if(col.isActiveAndEnabled)
        {
            col.enabled = false;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        //SetCourse();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void SetState(Vector3 _pos, int _atckOrder, int _damage)
    {
        targetPos = _pos;
        atckOrder = _atckOrder;
    }

    public IEnumerator MoveToTarget()
    {
        if (this.transform.position == targetPos)
        {
            col.enabled = true;
        }
        else
        {
            this.transform.position = targetPos;
        }
        yield return null;
    }

    public void SetCourse()
    {
        StartCoroutine(MoveToTarget());
    }

    
}
