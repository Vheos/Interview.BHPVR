namespace Vheos.Interview.BHPVR
{
	using System;
	using System.Linq;
	using UnityEngine;

	public class Extinguisher : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Animator Animator { get; private set; }
		[field: SerializeField] public ColliderEvent OnElementClicked { get; private set; }

		[field: SerializeField] public HandleLock HandleLock { get; private set; }
		[field: SerializeField] public MuzzleGun MuzzleGun { get; private set; }


		[field: SerializeField] public Collider[] LockColliders { get; private set; }
		[field: SerializeField] public Collider[] MuzzleColliders { get; private set; }
		[field: SerializeField] public Collider[] HandleColliders { get; private set; }

		// Methods
		private void DetectClickedElement(Collider collider)
		{
			if (LockColliders.Contains(collider))
				HandleLock.TryUnlock();
			else if (MuzzleColliders.Contains(collider))
				IsMuzzleReady = !IsMuzzleReady;
			else if (HandleColliders.Contains(collider))
			{
				TryToggleHandle();
			}
		}

		private void TryToggleHandle()
		{
			IsHandlePressed = !IsHandlePressed && HandleLock.IsUnlocked;
			MuzzleGun.IsSpraying = IsHandlePressed;
		}

		public bool IsMuzzleReady
		{
			get => Animator.GetBool(nameof(IsMuzzleReady));
			set => Animator.SetBool(nameof(IsMuzzleReady), value);
		}
		public bool IsHandlePressed
		{
			get => Animator.GetBool(nameof(IsHandlePressed));
			set => Animator.SetBool(nameof(IsHandlePressed), value);
		}

		// Unity
		private void OnEnable() => OnElementClicked.Subscribe(DetectClickedElement);
		private void OnDisable() => OnElementClicked.Subscribe(DetectClickedElement);
	}
}