namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;

	public class MuzzleGun : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
		[field: SerializeField] public Collider SprayArea { get; private set; }
		[field: SerializeField, Range(0f, 30f)] public float StartingAmmo { get; private set; }

		// Fields
		private float ammo;

		// Methods
		public float Ammo
		{
			get => ammo;
			private set
			{
				if (value == ammo)
					return;

				ammo = value;

				if (ammo <= 0f)
				{
					ammo = 0f;
					IsSpraying = false;
				}
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

		// Unity
		private void Awake() => ammo = StartingAmmo;
		private void FixedUpdate()
		{
			if (IsSpraying)
				Ammo -= Time.fixedDeltaTime;
		}
	}
}