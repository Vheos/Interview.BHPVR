namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;

	public class PowderGun : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[field: SerializeField] public Collider SprayArea { get; private set; }
		[field: SerializeField] public AudioSource AudioSource { get; private set; }
		[field: SerializeField] public GameFlags TutorialFlags { get; private set; }

		// Fields
		[field: SerializeField, Range(0f, 30f)] public float MaxAmmo { get; private set; }
		private float lastSfxTime;

		// Fields
		private float ammo;

		// Methods
		public float Ammo
		{
			get => ammo;
			private set
			{
				value = Mathf.Clamp(value, 0f, MaxAmmo);
				if (value == ammo)
					return;

				ammo = value;

				if (ammo == 0f)
					IsSpraying = false;
			}
		}
		public float AmmoPercent
			=> Ammo / MaxAmmo;
		public bool IsSpraying
		{
			get => ParticleSystem.isEmitting;
			set
			{
				if (value == IsSpraying)
					return;

				if (value && Ammo > 0f)
				{
					ParticleSystem.Play();
					AudioSource.time = lastSfxTime;
					AudioSource.Play();
					SprayArea.enabled = true;
					TutorialFlags[Flag.ExtinguisherIsSpraying] = true;
				}
				else if (!value)
				{
					ParticleSystem.Stop();
					lastSfxTime = AudioSource.time;
					AudioSource.Stop();
					SprayArea.enabled = false;
					TutorialFlags[Flag.ExtinguisherIsSpraying] = false;
				}
			}
		}
		private void TryReduceAmmo()
		{
			if (IsSpraying)
				Ammo -= Time.fixedDeltaTime;
		}

		// Unity
		private void Awake()
			=> Ammo = MaxAmmo;
		private void FixedUpdate()
			=> TryReduceAmmo();
	}
}