namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

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