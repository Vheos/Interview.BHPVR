namespace Vheos.Interview.BHPVR
{
	using System;
	using System.Linq;
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class Extinguisher : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Animator Animator { get; private set; }
		[field: SerializeField] public ColliderEvent OnElementClicked { get; private set; }
		[field: SerializeField] public Event OnUpdateHints { get; private set; }
		[field: SerializeField] public HandleLock HandleLock { get; private set; }
		[field: SerializeField] public AudioSource HandleAudioSource { get; private set; }
		[field: SerializeField] public PowderGun PowderGun { get; private set; }
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
				TryPressHandle();
		}
		private void TryPressHandle()
		{
			if (HandleLock.IsUnlocked && !IsHandlePressed)
				IsHandlePressed = true;
		}
		private void TryReleaseHandle()
		{
			if (Mouse.current.leftButton.wasReleasedThisFrame && IsHandlePressed)
				IsHandlePressed = false;
		}

		public bool IsMuzzleReady
		{
			get => Animator.GetBool(nameof(IsMuzzleReady));
			set => Animator.SetBool(nameof(IsMuzzleReady), value);
		}
		public bool IsHandlePressed
		{
			get => Animator.GetBool(nameof(IsHandlePressed));
			set
			{
				if (value == IsHandlePressed)
					return;

				Animator.SetBool(nameof(IsHandlePressed), value);
				PowderGun.IsSpraying = value;
				HandleAudioSource.Play();
			}
		}

		// Unity
		private void OnEnable()
			=> OnElementClicked.Subscribe(DetectClickedElement);
		private void Update()
			=> TryReleaseHandle();
		private void OnDisable()
			=> OnElementClicked.Unsubscribe(DetectClickedElement);
	}
}