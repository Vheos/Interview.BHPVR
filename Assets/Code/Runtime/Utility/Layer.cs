namespace Vheos.Interview.BHPVR
{
	public enum Layer
	{
		// Built-in
		Default = 0,
		TransparentFX = 1,
		IgnoreRaycast = 2,
		Water = 4,
		UI = 5,

		// Custom
		Clickable,
		ExtinguishingArea,
	}
}