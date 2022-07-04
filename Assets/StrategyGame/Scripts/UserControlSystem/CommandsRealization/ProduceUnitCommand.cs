using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [Inject(Id = "Cubik")] public float ProductionTime { get; }
    [Inject(Id = "Cubik")] public Sprite Icon { get; }
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("MainUnit")] protected GameObject _unitPrefab;
    [Inject(Id = "Cubik")] public string UnitName { get; }
}
