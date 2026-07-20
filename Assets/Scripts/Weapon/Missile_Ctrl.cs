using System.Collections;
using UnityEngine;

public class Missile_Ctrl : AttackObj_Ctrl
{
    Collider2D col;

    int armedTimer = 1;
    protected override void DamageProtocol(GameObject obj)
    {
        
    }

    protected override IEnumerator WeaponArmed()
    {

        yield return armedTimer--;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        if(col.isActiveAndEnabled)
        {
            col.enabled = false;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
