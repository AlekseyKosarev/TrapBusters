using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mine/Create MineDataContainer", fileName = "MineDataContainer", order = 0)]
public class MineDataContainer : ScriptableObject
{
    public List<MineData> Mines => _mines;
    
    [SerializeField]
    private List<MineData> _mines;
}