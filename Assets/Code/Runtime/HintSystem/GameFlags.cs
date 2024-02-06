namespace Vheos.Interview.BHPVR
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(GameFlags), menuName = AssetMenuPaths.Root + nameof(GameFlags))]
	public class GameFlags : ScriptableObject
	{
		// Fields
		private readonly HashSet<Flag> flags = new();

		// Events
		public event Action OnChange;

		// Methods
		public void ResetAll()
			=> flags.Clear();
		public void PrintDebugLog()
			=> Debug.Log($"Flags: {flags.Count}\n" + string.Join('\n', flags.Select(flag => $"\t- {flag}")));

		// Operators
		public bool this[Flag flag]
		{
			get => flags.Contains(flag);
			set
			{
				if (value && flags.Add(flag)
				|| !value && flags.Remove(flag))
					OnChange?.Invoke();
			}
		}
	}
}