namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class Fire : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[field: SerializeField] public Layer ExtinguishingLayer { get; private set; }
		[field: SerializeField] public Rigidbody Rigidbody { get; private set; }
		[field: SerializeField, Range(0f, 30f)] public float StartingHealth { get; private set; }
		[field: SerializeField, Range(0f, 5f)] public float HealthRegen { get; private set; }

		// Fields
		private float health;
		private int extinguishingLayerMask;
		private bool hasBeenSprayedThisFrame;

		// Methods
		public float Health
		{
			get => health;
			private set
			{
				if (value == health)
					return;

				health = value;

				if (health <= 0f)
					Destroy(gameObject);
			}
		}
		private void Initialize()
		{
			health = StartingHealth;
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
			if (!hasBeenSprayedThisFrame && health < StartingHealth)
				Health += HealthRegen * Time.fixedDeltaTime;
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