using System.Collections;
using UnityEngine;

public class Mine_Ctrl : AttackObj_Ctrl
{
    public override void SetState(Vector3 _targetPos, int _atckOrder, int _damage)
    {
        atckOrder = _atckOrder;
    }

    protected override void DamageProtocol(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator WeaponArmed()
    {
        throw new System.NotImplementedException();
    }

    
}
