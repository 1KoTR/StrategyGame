using UnityEngine;

[RequireComponent(typeof(OutlineExecutor))]
public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => _pivotPoint;
    public Sprite Icon => _icon;

    [SerializeField] private float _health = 1000;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private Sprite _icon;
}
