namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class Hose : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public LineRenderer LineRenderer { get; private set; }
		[field: SerializeField] public Transform[] Targets { get; private set; }

		// Fields
		private Vector3[] positions;

		// Methods
		private void UpdatePositions()
		{
			for (int i = 0; i < positions.Length; i++)			
				positions[i] = Targets[i].position;
			
			LineRenderer.SetPositions(positions);
		}

		// Unity
		protected void Awake() 
			=> positions = new Vector3[Targets.Length];
		protected void Update()
			=> UpdatePositions();
	}
}