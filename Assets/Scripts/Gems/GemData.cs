using UnityEngine;

namespace Gems
{
    
    [CreateAssetMenu(menuName = "Create GemData", fileName = "GemData", order = 0)]
    public class GemData : ScriptableObject
    {
        public int Index;
        public string GameName;
        public Sprite GemSprite;
        public float BaseSellPrice;
        public GemController GemPrefab;
    }
}