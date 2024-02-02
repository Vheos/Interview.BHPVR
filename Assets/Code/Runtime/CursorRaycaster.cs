namespace Vheos.Interview.BHPVR
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class CursorRaycaster : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Camera Camera { get; private set; }
		[field: SerializeField] public ColliderEvent OnHit { get; private set; }

		// Fields
		[field: SerializeField] public string[] Layers { get; private set; }
		private int layerMask;

		// Methods
		private Vector2 CursorPosition
			=> Mouse.current.position.ReadValue();
		private Ray CursorRay
			=> Camera.ScreenPointToRay(CursorPosition);
		private void InitializeLayerMask()
			=> layerMask = LayerMask.GetMask(Layers);
		private bool ClickedThisFrame()
			=> Mouse.current.leftButton.wasPressedThisFrame;
		public bool Raycast(out RaycastHit hit)
			=> Physics.Raycast(CursorRay, out hit, float.PositiveInfinity, layerMask);
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