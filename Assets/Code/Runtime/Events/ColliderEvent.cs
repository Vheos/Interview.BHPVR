namespace Vheos.Interview.BHPVR
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(ColliderEvent), menuName = AssetMenuPaths.Events + nameof(ColliderEvent))]
    public class ColliderEvent : ScriptableEvent<Collider>
    { }
}