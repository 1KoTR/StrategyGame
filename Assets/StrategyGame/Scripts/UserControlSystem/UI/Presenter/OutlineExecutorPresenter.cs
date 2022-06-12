using UnityEngine;

public class OutlineExecutorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;

    private OutlineExecutor _outlineExecutor;
    private ISelectable _currentSelectedObject;

    private void Start()
    {
        _selectedObject.OnNewValue += OnSelected;
        OnSelected(_selectedObject.CurrentValue);
    }

    private void OnSelected(ISelectable selectedObject)
    {
        if (_currentSelectedObject == selectedObject)
            return;
        _currentSelectedObject = selectedObject;

        if (_outlineExecutor != null)
        {
            _outlineExecutor.enabled = false;
            _outlineExecutor = null;
        }
        if (_currentSelectedObject != null)
        {
            _outlineExecutor = (selectedObject as Component).GetComponent<OutlineExecutor>();
            _outlineExecutor.enabled = true;
        }
    }
}
