using System.Collections;
using UnityEngine;

interface MovableObj
{
    IEnumerator MoveToTarget();

    public void SetCourse();
}
public abstract class AttackObj_Ctrl : MonoBehaviour
{
    protected float damage;

    protected bool isArmed;

    //LayerMask layermask = LayerMask.GetMask("Water");

    protected virtual void Start()
    {
        StartCoroutine(WeaponArmed());
    }
    protected abstract IEnumerator WeaponArmed();


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        StopAllCoroutines();

        if (collision.gameObject.CompareTag("Unit") || collision.gameObject.CompareTag("Weapon"))
        {
            DamageProtocol(collision.gameObject);
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }

    protected abstract void DamageProtocol(GameObject obj);
}
