namespace Vheos.Interview.BHPVR
{
	using TMPro;
	using UnityEngine;

	public class TutorialManager : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public TextMeshProUGUI Text { get; private set; }
		[field: SerializeField] public TutorialLine Line { get; private set; }
		[field: SerializeField] public Camera Camera { get; private set; }
		[field: SerializeField] public GameFlags TutorialFlags { get; private set; }
		[field: SerializeField] public Hint[] Hints { get; private set; }

		// Fields
		private Hint currentHint;

		// Methods
		private void UpdateLine(Transform target)
		{
			if (target == null)
			{
				Line.enabled = false;
				return;
			}

			Vector3 targetPosition = target.TryGetComponent<Collider>(out var collider) ? collider.bounds.center : target.position;

			Plane plane = new(-Camera.transform.forward, targetPosition);
			Ray ray = new(Camera.transform.position, Camera.transform.forward);
			plane.Raycast(ray, out float distance);

			Vector3 panelScreenPosition = transform.position;
			panelScreenPosition.z = distance;

			Line.SetPositions(Camera.ScreenToWorldPoint(panelScreenPosition), targetPosition);
			Line.enabled = true;
		}

		private void UpdateHint()
		{
			foreach (var hint in Hints)
				if (TutorialFlags[hint.Flag] == hint.State)
				{
					if (hint == currentHint)
						return;

					currentHint = hint;
					Text.text = hint.Text;
					UpdateLine(hint.LineTarget);
					return;
				}
		}

		// Awake
		private void Awake()
			=> UpdateHint();
		private void OnEnable()
			=> TutorialFlags.OnChange += UpdateHint;
		private void OnDisable()
			=> TutorialFlags.OnChange -= UpdateHint;
	}
}