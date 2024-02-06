namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class TutorialLine : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public LineRenderer LineRenderer { get; private set; }

		// Fields
		private readonly Vector3[] positions = new Vector3[3];

		// Methods
		public void SetPositions(Vector3 from, Vector3 to)
		{
			positions[0] = from;
			positions[1] = new(from.x, to.y);
			positions[2] = to;
			LineRenderer.SetPositions(positions);
		}

		// Unity
		protected void OnEnable()
			=> LineRenderer.enabled = true;
		protected void OnDisable()
			=> LineRenderer.enabled = false;
	}
}