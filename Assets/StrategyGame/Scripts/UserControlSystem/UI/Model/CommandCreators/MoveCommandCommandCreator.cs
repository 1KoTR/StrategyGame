using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
{
    protected override IMoveCommand createCommand(Vector3 argument) => new MoveCommand(argument);
}
