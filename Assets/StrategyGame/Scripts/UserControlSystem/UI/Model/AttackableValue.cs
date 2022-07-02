using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(AttackableValue),
    menuName = "Strategy Game/" + nameof(AttackableValue),
    order = 0)]
public class AttackableValue : StatelessScriptableObjectValueBase<IAttackable>
{

}
