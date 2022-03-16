using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class IconInfo : ScriptableObject
    {
        [SerializeField] private string iconName, prefabName;

        public string IconName => iconName;
        public string PrefabName => prefabName;
        

    }
}