using UnityEngine;
using Value;

namespace Gems
{
    [CreateAssetMenu(menuName = "Create GemData", fileName = "GemData", order = 0)]
    public class GemData : ScriptableObject
    {
        public int Index;
        public string GameName;
        public Sprite GemSprite;
        public float BaseSellPrice;
        public IntRefValue SellCount;
        public GemController GemPrefab;
        public string SellCountSaveKey;

        public void SellGem()
        {
            SellCount.Value++;
            Save();
        }

        public void Load()
        {
            SellCount.Value = PlayerPrefs.GetInt(SellCountSaveKey);
        }

        private void Save()
        {
            PlayerPrefs.SetInt(SellCountSaveKey, SellCount.Value);
        }
    }
}