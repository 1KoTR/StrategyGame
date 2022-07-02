using System;
using UnityEngine;
using UniRx;
using Zenject;

public class OutlineExecutorPresenter : MonoBehaviour
{
    [Inject] private IObservable<ISelectable> _selectedObject;

    private OutlineExecutor _outlineExecutor;
    private ISelectable _currentSelectedObject;

    private void Start()
    {
        _selectedObject.Subscribe(OnSelected);
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
