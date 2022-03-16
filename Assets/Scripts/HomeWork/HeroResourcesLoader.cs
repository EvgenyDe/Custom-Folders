using UnityEngine;

namespace DefaultNamespace
{
    public class HeroResourcesLoader : MonoBehaviour
    {
        //[SerializeField] private SpriteRenderer baseSprite; //TODO hairColor
       // [SerializeField] private Texture baseHairTexture;
        
        [SerializeField] private Transform prefabRoot;

        [SerializeField] private string[] heroes = new string[2];

        private HeroInfo _config;

        private GameObject _currentPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetupIcon(heroes[0]);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetupIcon(heroes[1]);
            }
            
        }

        private void SetupIcon(string configName)
        {
            _config = Resources.Load<HeroInfo>($"ConfigsHero/{configName}");
            var prefab = Resources.Load<GameObject>($"HeroPrefabs/{_config.PrefabName}");
            
           // var texture = Resources.Load<Texture>($"IconsHeroTextures/{_config.HairColor}");

            //var sprite = Resources.Load<Sprite>($"Icons/{config.IconName}");
            //baseSprite.sprite = sprite;

            if (_currentPrefab != null)
            {
                Destroy(_currentPrefab);
            }

            _currentPrefab = Instantiate(prefab, prefabRoot);
        }
        
        
        public void SetHairColor(string hairColor)
        {
            _config.HairMaterial = hairColor;
            
            var material = Resources.Load<Material>($"IconsHeroTextures/{_config.HairMaterial}");

            if (hairColor == "white")
            {
                material.color = Color.white;
            }

            if (hairColor == "black")
            {
                material.color = Color.black;
            }
        }

    }
    
}
