using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class HeroInfo : ScriptableObject
    {
        [SerializeField] private string heroName, prefabName,hairMaterial;
        
        
        //искать волосы по стринге ? надо понять как хранятя волосы в проекте

        public string HairMaterial
        {
            get => hairMaterial;
            set => hairMaterial = value;
        }

        public string HeroName => heroName;
        public string PrefabName => prefabName;
        

    }
}