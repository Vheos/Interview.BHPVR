namespace Vheos.Interview.BHPVR
{
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class CursorRaycaster : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Camera Camera { get; private set; }
		[field: SerializeField] public ColliderEvent OnHit { get; private set; }

		// Fields
		[field: SerializeField, Range(0f, 1f)] public float RayRadius { get; private set; }
		[field: SerializeField] public Layer[] Layers { get; private set; }
		private int layerMask;

		// Methods
		private Vector2 CursorPosition
			=> Mouse.current.position.ReadValue();
		private Ray CursorRay
			=> Camera.ScreenPointToRay(CursorPosition);
		private void InitializeLayerMask()
			=> layerMask = Layers.ToLayerMask();
		private bool ClickedThisFrame()
			=> Mouse.current.leftButton.wasPressedThisFrame;
		public bool Raycast(out RaycastHit hit)
			=> RayRadius <= 0f
			? Physics.Raycast(CursorRay, out hit, float.PositiveInfinity, layerMask)
			: Physics.SphereCast(CursorRay, RayRadius, out hit, float.PositiveInfinity, layerMask);
		private void DetectHits()
		{
			if (ClickedThisFrame() && Raycast(out var hit))
				OnHit.Invoke(hit.collider);
		}

		// Unity
		private void Awake()
			=> InitializeLayerMask();
		private void Update()
			=> DetectHits();
	}
}