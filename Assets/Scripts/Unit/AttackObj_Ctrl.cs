using System.Collections;
using UnityEngine;

interface MovableObj
{
    
    IEnumerator MoveToTarget();

    /// <summary>
    /// È£Ãâ¿ë
    /// </summary>
    public void SetCourse();
}
public abstract class AttackObj_Ctrl : MonoBehaviour
{
    protected int damage;

    protected bool isArmed;

    protected int atckOrder;

    protected Vector3 targetPosition;
    //LayerMask layermask = LayerMask.GetMask("Water");

    protected virtual void Start()
    {
        
    }
    protected virtual void OnEnable()
    {
        if(atckOrder == 0)
        {
            Stage_Manager.instance.AddMyAttack(this.gameObject);
        }
        else
        {
            Stage_Manager.instance.AddEnemyAttack(this.gameObject);
        }

        //StartCoroutine(WeaponArmed());
    }
    protected abstract IEnumerator WeaponArmed();

    public abstract void SetState(Vector3 _targetPos, int _atckOrder, int _damage);


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (isArmed)
        {
            StopAllCoroutines();


            DamageProtocol(collision.gameObject);

            if (atckOrder == 0)
            {
                Stage_Manager.instance.RemoveMyAttack(this.gameObject);
            }
            else
            {
                Stage_Manager.instance.RemoveEnemyAttack(this.gameObject);
            }
            this.gameObject.SetActive(false);
        }
    }
    protected abstract void DamageProtocol(GameObject obj);
}
