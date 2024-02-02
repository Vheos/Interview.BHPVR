namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class Hose : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public LineRenderer LineRenderer { get; private set; }
		[field: SerializeField] public Transform From { get; private set; }
		[field: SerializeField] public Transform To { get; private set; }

		// Fields
		private readonly Vector3[] positions = new Vector3[2];

		// Methods
		private void UpdatePositions()
		{
			positions[0] = From.position;
			positions[1] = To.position;
			LineRenderer.SetPositions(positions);
		}

		// Unity
		protected void Update()
			=> UpdatePositions();
	}
}