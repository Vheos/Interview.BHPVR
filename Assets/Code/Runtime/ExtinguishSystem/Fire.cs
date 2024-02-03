namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class Fire : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[field: SerializeField] public Layer ExtinguishingLayer { get; private set; }
		[field: SerializeField, Range(1f, 30f)] public float MaxHealth { get; private set; }
		[field: SerializeField, Range(0f, 5f)] public float HealthRegen { get; private set; }
		[field: SerializeField] public AnimationCurve SizeByHealth { get; private set; }

		// Fields
		private float health;
		private int extinguishingLayerMask;
		private bool hasBeenSprayedThisFrame;

		// Methods
		public bool IsBurning
			=> ParticleSystem.isEmitting;
		public float Health
		{
			get => health;
			private set
			{
				health = Mathf.Clamp(value, 0f, MaxHealth);
				UpdateSize();

				if (health == 0f)
					ParticleSystem.Stop();
			}
		}
		private void Initialize()
		{
			Health = MaxHealth;
			extinguishingLayerMask = ExtinguishingLayer.ToLayerMask();
		}
		private void TryGetSprayed(Collider other)
		{
			if (other.gameObject.layer != extinguishingLayerMask)
				return;

			Health -= Time.fixedDeltaTime;
			hasBeenSprayedThisFrame = true;
		}
		private void TryRegenHealth()
		{
			if (IsBurning && !hasBeenSprayedThisFrame)
				Health += HealthRegen * Time.fixedDeltaTime;
		}
		private void UpdateSize()
		{
			float size = SizeByHealth.Evaluate(health / MaxHealth);
			ParticleSystem.transform.localScale = new(size, size, size);
		}

		// Unity
		private void Awake()
			=> Initialize();
		private void FixedUpdate()
		{
			TryRegenHealth();
			hasBeenSprayedThisFrame = false;
		}
		private void OnTriggerStay(Collider other)
			=> TryGetSprayed(other);
	}
}