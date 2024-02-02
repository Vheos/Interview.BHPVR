namespace Vheos.Interview.BHPVR
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public static class Helpers
	{
		public static int ToLayerMask(this Layer layer)
			=> LayerMask.NameToLayer(layer.ToString());
		public static int ToLayerMask(this IEnumerable<Layer> layers)
			=> LayerMask.GetMask(layers.Select(layer => layer.ToString()).ToArray());
	}
}