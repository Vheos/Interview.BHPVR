namespace Vheos.Interview.BHPVR
{
	using UnityEngine;

	public class Fire : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[field: SerializeField] public AudioSource AudioSource { get; private set; }
		[field: SerializeField] public GameFlags TutorialFlags { get; private set; }

		// Fields
		[field: SerializeField] public Layer ExtinguishingLayer { get; private set; }
		[field: SerializeField, Range(1f, 15f)] public float MaxHealth { get; private set; }
		[field: SerializeField, Range(0f, 2f)] public float HealthRegen { get; private set; }
		[field: SerializeField] public AnimationCurve SizeByHealth { get; private set; }
		[field: SerializeField] public AnimationCurve VolumeByHealth { get; private set; }
		[field: SerializeField] public AnimationCurve PitchByHealth { get; private set; }
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
				value = Mathf.Clamp(value, 0f, MaxHealth);
				if (value == health)
					return;

				health = value;
				UpdateSizeAndAudio();

				if (health == 0f)
					Die();
			}
		}
		public float HealthPercent
			=> Health / MaxHealth;
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
				Health += HealthPercent * HealthRegen * Time.fixedDeltaTime;
		}
		private void UpdateSizeAndAudio()
		{
			float percent = HealthPercent;
			float size = SizeByHealth.Evaluate(percent);
			ParticleSystem.transform.localScale = new(size, size, size);
			AudioSource.volume = VolumeByHealth.Evaluate(percent);
			AudioSource.pitch = PitchByHealth.Evaluate(percent);
		}
		private void Die()
		{
			ParticleSystem.Stop();
			AudioSource.Stop();
			TutorialFlags[Flag.FireIsExtinguished] = true;
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