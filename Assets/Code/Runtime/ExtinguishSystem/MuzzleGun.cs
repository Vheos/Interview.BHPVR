namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;

	public class MuzzleGun : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[field: SerializeField] public Collider SprayArea { get; private set; }
		[field: SerializeField, Range(0f, 30f)] public float MaxAmmo { get; private set; }

		// Fields
		private float ammo;

		// Methods
		public float Ammo
		{
			get => ammo;
			private set
			{
				ammo = Mathf.Clamp(value, 0f, MaxAmmo);

				if (ammo == 0f)
					IsSpraying = false;
			}
		}
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
					SprayArea.enabled = true;
				}
				else if (!value)
				{
					ParticleSystem.Stop();
					SprayArea.enabled = false;
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