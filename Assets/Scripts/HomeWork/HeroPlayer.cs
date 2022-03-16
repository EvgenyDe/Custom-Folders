using UnityEngine;

namespace DefaultNamespace
{
    public class HeroPlayer : MonoBehaviour
    {
        [SerializeField] private HeroButton baseButton;
        private HeroConfig config;

        private void Start()
        {
            config = Resources.Load<HeroConfig>("HeroConfig");

            var names = config.Heroes;

            foreach (var objName in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                btn.Setup(objName,OnHeroButton);
            }
            
            baseButton.Setup("Random",OnRandomHeroButton);
        }

        private void OnRandomHeroButton(string id)
        {
            var asset = config.GetRandomHero();
            var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
            Destroy(obj,5f);
        }

        private void OnHeroButton(string id)
        {
            var asset = config.GetHero(id);
            var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
            Destroy(obj,5f);
        }
    }
}