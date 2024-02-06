#if UNITY_EDITOR
namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class ResetGameFlagsOnExitPlayMode : MonoBehaviour
	{
		// Fields
		[field: SerializeField] public GameFlags GameFlags { get; private set; }

		// Unity
		private void OnDestroy()
			=> GameFlags.ResetAll();
	}
}
#endif