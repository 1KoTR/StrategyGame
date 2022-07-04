using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;

    enum AnimationType
    {
        Idle,
        Walk,
    }

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;
        print(nameof(AnimationType.Walk));
        _animator.SetTrigger(nameof(AnimationType.Walk));
        _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
        try
        {
            await _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
        }
        catch
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
        }
        _stopCommandExecutor.CancellationTokenSource = null;
        _animator.SetTrigger(nameof(AnimationType.Idle));
    }
}
