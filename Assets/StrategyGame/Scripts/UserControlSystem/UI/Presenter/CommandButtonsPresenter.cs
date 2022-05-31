using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;

    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);
        _view.OnClick += OnButtonClick;
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable) return;

        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    private void OnButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            //unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }
        var attacker = commandExecutor as CommandExecutorBase<IAttackCommand>;
        if (attacker != null)
        {
            attacker.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
            return;
        }
        var mover = commandExecutor as CommandExecutorBase<IMoveCommand>;
        if (mover != null)
        {
            mover.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
            return;
        }
        var patroler = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        if (patroler != null)
        {
            patroler.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
            return;
        }
        var stopper = commandExecutor as CommandExecutorBase<IStopCommand>;
        if (stopper != null)
        {
            stopper.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
            return;
        }
        throw new ApplicationException
            (
                $"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)} : " + 
                $"Unknown type of commands executor: { commandExecutor.GetType().FullName }!"
            );
    }
}