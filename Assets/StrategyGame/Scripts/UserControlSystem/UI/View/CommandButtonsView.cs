using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecutor> OnClick;

    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _patrolButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _produceUnitButton;

    private Dictionary<Type, GameObject> _buttonsByExecutorType;

    private void Start() => _buttonsByExecutorType = new Dictionary<Type, GameObject>
        {
            { typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton },
            { typeof(CommandExecutorBase<IAttackCommand>), _attackButton },
            { typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
            { typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton },
            { typeof(CommandExecutorBase<IStopCommand>), _stopButton }
        };

    public void BlockInteractions(ICommandExecutor commandExecutor)
    {
        UnblockAllInteractions();
        GetButtonGameObjectByType(commandExecutor.GetType()).GetComponent<Selectable>().interactable = false;
    }

    public void UnblockAllInteractions() => SetInteractible(true);

    private void SetInteractible(bool value)
    {
        _attackButton.GetComponent<Selectable>().interactable = value;
        _moveButton.GetComponent<Selectable>().interactable = value;
        _patrolButton.GetComponent<Selectable>().interactable = value;
        _stopButton.GetComponent<Selectable>().interactable = value;
        _produceUnitButton.GetComponent<Selectable>().interactable =value;
    }


    public void MakeLayout(List<ICommandExecutor> commandExecutors)
    {
        foreach (var currentExecutor in commandExecutors)
        {
            var buttonGameObject = GetButtonGameObjectByType(currentExecutor.GetType());
            buttonGameObject.SetActive(true);
            var button = buttonGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
        }
    }

    private GameObject GetButtonGameObjectByType(Type executorInstanceType) =>
        _buttonsByExecutorType.Where(type => type.Key.IsAssignableFrom(executorInstanceType)).First().Value;

    public void Clear()
    {
        foreach (var kvp in _buttonsByExecutorType)
        {
            kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
            kvp.Value.SetActive(false);
        }
    }

}
