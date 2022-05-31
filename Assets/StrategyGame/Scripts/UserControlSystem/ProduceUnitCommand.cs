using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;

    [InjectAsset("MainUnit")] protected GameObject _unitPrefab;
}
