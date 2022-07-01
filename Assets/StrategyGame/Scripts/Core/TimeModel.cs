using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Zenject;

public class TimeModel : ITimeModel, ITickable
{
    public IObservable<int> GameTime => _gameTime.Select(f => (int)f);

    private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();

    public void Tick()
    {
        _gameTime.Value += Time.deltaTime;
    }
}
