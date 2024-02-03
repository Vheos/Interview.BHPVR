namespace Vheos.Interview.BHPVR
{
	using UnityEngine;
	using UnityEngine.UI;

	public class PositionOffsetSlider : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Slider Slider { get; private set; }
		[field: SerializeField] public Transform Target { get; private set; }

		// Fields
		[field: SerializeField] public Vector3 MaxOffset { get; private set; }
		[field: SerializeField] public bool UseWorldSpace { get; private set; }
		private float previousValue;

		// Methods
		private void ApplyOffset(float value)
		{
			Vector3 offset = (value - previousValue) * MaxOffset;
			if (UseWorldSpace)
				Target.transform.position += offset;
			else
				Target.transform.localPosition += offset;

			previousValue = value;
		}

		// Unity
		private void OnEnable()
			=> Slider.onValueChanged.AddListener(ApplyOffset);
		private void OnDisable()
			=> Slider.onValueChanged.RemoveListener(ApplyOffset);
	}
}