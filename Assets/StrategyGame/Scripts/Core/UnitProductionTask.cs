using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProductionTask : IUnitProductionTask
{
    public string UnitName { get; }
    public float TimeLeft { get; set; }
    public float ProductionTime { get; }
    public Sprite Icon { get; }
    public GameObject UnitPrefab { get; }

    public UnitProductionTask(float time, Sprite icon, GameObject gameObject, string unitName)
    {
        Icon = icon;
        TimeLeft = time;
        ProductionTime = time;
        UnitPrefab = gameObject;
        UnitName = unitName;
    }
}
