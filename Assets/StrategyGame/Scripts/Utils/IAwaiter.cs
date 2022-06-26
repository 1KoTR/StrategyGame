using System.Runtime.CompilerServices;

public interface IAwaiter<TAwaiter> : INotifyCompletion
{
    bool IsCompleted { get; }
    TAwaiter GetResult();
}
