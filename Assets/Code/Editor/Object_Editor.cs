#if UNITY_EDITOR
namespace Vheos.Interview.BHPVR.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CustomEditor(typeof(Object), true)]
	[CanEditMultipleObjects]
	public class Object_Editor : Editor
	{
		override public void OnInspectorGUI()
		{
			DrawPropertiesExcluding(serializedObject, "m_Script");
			serializedObject.ApplyModifiedProperties();
		}
	}
}
#endif