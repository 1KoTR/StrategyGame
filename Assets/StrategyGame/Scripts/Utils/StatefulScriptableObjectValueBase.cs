using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class StatefulScriptableObjectValueBase<T> : ValueBase<T>, IObservable<T>
{
    private ReactiveProperty<T> _innerDataSource = new();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.Value = value;
    }
    public IDisposable Subscribe(IObserver<T> observer) => _innerDataSource.Subscribe(observer);
}
