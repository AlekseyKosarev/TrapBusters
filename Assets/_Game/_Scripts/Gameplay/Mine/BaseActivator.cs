using System;
using UnityEngine;

public class BaseActivator : MonoBehaviour
{
    public event Action OnActivated;
    
    protected virtual void Activate()
    {
        OnActivated?.Invoke();
        Debug.Log("BaseActivator Activate");
    }
}