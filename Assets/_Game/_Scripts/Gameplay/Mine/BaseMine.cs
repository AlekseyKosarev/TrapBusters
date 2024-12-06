using UnityEngine;

public class BaseMine: MonoBehaviour
{
    [SerializeField]
    private BaseActivator _baseActivator;

    private MineModel _mine;
    public virtual void Init(MineModel mine)
    {
        _baseActivator.OnActivated += Explode;
    }

    protected virtual void OnDestroy()
    {
        _baseActivator.OnActivated -= Explode;
    }

    protected virtual void Explode()
    {
        Debug.Log("Explode");
    }
}