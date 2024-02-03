namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;
	using UnityEngine.InputSystem;
	using UnityEngine.UI;

	public class FireHealthBar : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ValueBar ValueBar { get; private set; }
		[field: SerializeField] public Fire Fire { get; private set; }

		// Methods
		private void InitializeValueBar()
			=> ValueBar.GetPercentValue = () => Fire.HealthPercent;

		// Unity
		private void Awake()
			=> InitializeValueBar();
	}
}