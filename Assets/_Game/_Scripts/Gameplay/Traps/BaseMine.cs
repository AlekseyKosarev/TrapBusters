using System;
using Unity.Netcode;
using UnityEngine;

public class BaseMine: NetworkBehaviour
{
    public float damage;
    public float radius = 10f;
    public float delay;
    
    private bool _activated;
    
    [Rpc(SendTo.Server)]
    public virtual void ExplodeRpc()
    {
        _activated = true;
        var colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hit in colliders)
        {
            if (hit.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }
    
    [Rpc(SendTo.Server)]
    public virtual void CheckActivateRpc(StadesActivate stadesActivate)
    {
        if(_activated) return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("enter" + other.name);
            CheckActivateRpc(StadesActivate.Enter);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("exit" + other.name); 
            CheckActivateRpc(StadesActivate.Exit);
        }
    }
}

public enum StadesActivate
{
    Enter,
    Stay,
    Exit
}