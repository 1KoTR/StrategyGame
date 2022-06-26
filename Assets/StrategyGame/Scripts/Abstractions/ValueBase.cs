using System;
using UnityEngine;

public abstract class ValueBase<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly ValueBase<TAwaited> _valueBase;

        public NewValueNotifier(ValueBase<TAwaited> valueBase)
        {
            _valueBase = valueBase;
            _valueBase.OnNewValue += onNewValue;
        }

        private void onNewValue(TAwaited obj)
        {
            _valueBase.OnNewValue -= onNewValue;
            onWaitFinish(obj);
        }
    }

    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
    public IAwaiter<T> GetAwaiter() => new NewValueNotifier<T>(this);
}
