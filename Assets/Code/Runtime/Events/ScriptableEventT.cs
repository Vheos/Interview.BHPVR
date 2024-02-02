namespace Vheos.Interview.BHPVR
{
    using System;
    using UnityEngine;

    public abstract class ScriptableEvent<T> : ScriptableObject
    {
        // Fields
        private event Action<T> Event;

        // Methods
        public void Subscribe(Action<T> action)
            => Event += action;
        public void Unsubscribe(Action<T> action)
            => Event -= action;
        public void Invoke(T value)
            => Event?.Invoke(value);
    }
}