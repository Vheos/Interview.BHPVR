namespace Vheos.Interview.BHPVR
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Hint
	{
		public Flag Flag;
		public bool State;
		[Multiline] public string Text;
		public Transform LineTarget;
	}
}