namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class PowderAmmoBar : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ValueBar ValueBar { get; private set; }
		[field: SerializeField] public Extinguisher Extinguisher { get; private set; }

		// Methods
		private void InitializeValueBar()
			=> ValueBar.GetPercentValue = () => Extinguisher.MuzzleGun.AmmoPercent;

		// Unity
		private void Awake()
			=> InitializeValueBar();
	}
}