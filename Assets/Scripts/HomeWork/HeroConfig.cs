using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class HeroConfig : ScriptableObject
    {
        [SerializeField] private string[] heroes;
        public string[] Heroes => heroes;

        public GameObject GetRandomEffect()
        {
            var effectName = heroes[Random.Range(0, heroes.Length)];
            return LoadObject(effectName);
        }

        private GameObject LoadObject(string effectName)
        {
            return Resources.Load<GameObject>($"Heroes/{effectName}");
        }

        public GameObject GetEffect(string effectName)
        {
            var objName = heroes.FirstOrDefault(e => e == effectName);
            return string.IsNullOrEmpty(objName) ? null : LoadObject(effectName);
        }
        
        #if UNITY_EDITOR

        private void Reset()
        {
            var objects = Resources.LoadAll<GameObject>("Heroes");
            heroes = new string[objects.Length];

            for (int i = 0; i < heroes.Length; i++)
            {
                heroes[i] = objects[i].name;
            }
        }
#endif
    }
}