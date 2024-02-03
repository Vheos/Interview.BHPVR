namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;
	using UnityEngine.UI;

	public class ValueBar : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Slider Slider { get; private set; }
		[field: SerializeField] public Image Fill { get; private set; }
		public Func<float> GetPercentValue { get; set; } = () => throw new NotImplementedException();

		// Fields
		[field: SerializeField] public Gradient Gradient { get; private set; }

		// Methods
		private void TryUpdateValue()
		{
			float value = GetPercentValue();
			if (value == Slider.value)
				return;

			Slider.value = value;
			Fill.color = Gradient.Evaluate(value);
		}

		// Unity
		private void Update()
			=> TryUpdateValue();
	}
}