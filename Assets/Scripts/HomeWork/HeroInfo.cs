using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class HeroInfo : ScriptableObject
    {
        [SerializeField] private string heroName, prefabName,hairColor;
        
        
        //искать волосы по стринге ? надо понять как хранятя волосы в проекте

        public string HairColor => hairColor;

        public string HeroName => heroName;
        public string PrefabName => prefabName;
        

    }
}