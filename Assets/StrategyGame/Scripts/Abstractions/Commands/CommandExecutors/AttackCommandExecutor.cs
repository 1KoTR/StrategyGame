public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        print($"{name} is attacking {command.Target} with {command.Target.Health}/{command.Target.MaxHealth} health!");
    }
}
