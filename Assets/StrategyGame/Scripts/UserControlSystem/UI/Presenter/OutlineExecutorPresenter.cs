using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineExecutorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;

    [SerializeField] private OutlineExecutor _outlineExecutor;
    private ISelectable _currentSelectedObject;

    private void Start()
    {
        _selectedObject.OnSelected += OnSelected;
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
            _outlineExecutor = (selectedObject as Component).GetComponentInParent<OutlineExecutor>();
            _outlineExecutor.enabled = true;
        }
    }
}
