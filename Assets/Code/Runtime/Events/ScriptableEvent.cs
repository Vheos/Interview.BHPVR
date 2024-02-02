namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;

	public class ScriptableEvent : ScriptableObject
	{
		// Fields
		private event Action Event;

		// Methods
		public void Subscribe(Action action)
			=> Event += action;
		public void Unsubscribe(Action action)
			=> Event -= action;
		public void Invoke()
			=> Event?.Invoke();
	}
}