using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        print($"{name} move!");
    }
}
