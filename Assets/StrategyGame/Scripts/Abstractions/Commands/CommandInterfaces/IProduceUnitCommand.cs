using UnityEngine;

public interface IProduceUnitCommand : ICommand, IIconHolder
{
    float ProductionTime { get; }
    public GameObject UnitPrefab { get; }
    string UnitName { get; }
}
