public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        print($"{name} is patrolling from {command.From} to {command.To}!");
    }
}
