using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Mine/Create MineData", fileName = "MineData", order = 0)]
public class MineData : ScriptableObject
{
    public MineModel MineModel => _mineModel;
    
    [SerializeField]
    private MineModel _mineModel;
}

[Serializable]
public class MineModel
{
    public int Damage;

    public MineModel(int damage)
    {
        Damage = damage;
    }
}