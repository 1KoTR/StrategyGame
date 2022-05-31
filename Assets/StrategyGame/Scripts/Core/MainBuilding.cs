using UnityEngine;

[RequireComponent(typeof(Outline))]
public class MainBuilding : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Outline Outline => _outline;

    [SerializeField] private float _health = 1000;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }
}
