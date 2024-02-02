namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class HandleLock : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Animator Animator { get; private set; }
		[field: SerializeField] public Rigidbody Rigidbody { get; private set; }

		// Fields
		public bool IsUnlocked { get; private set; }

		// Methods
		public void TryUnlock()
		{
			if (IsUnlocked)
				return;

			IsUnlocked = true;
			Animator.enabled = true;
		}
		public void EnableRagdoll()
		{
			transform.parent = null;
			Animator.enabled = false;
			Rigidbody.isKinematic = false;
		}
	}
}