using UnityEngine;

[RequireComponent(typeof(OutlineExecutor))]
public class MainBuilding : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private float _health = 1000;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
}
