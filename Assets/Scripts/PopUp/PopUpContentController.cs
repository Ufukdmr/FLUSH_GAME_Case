
using System;
using Gems;
using TMPro;
using UnityEngine;
using Value;
using Image = UnityEngine.UI.Image;

namespace PopUp
{
    public class PopUpContentController : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private GemData Data;
        [SerializeField] private Image Icon;
        [SerializeField] private TMP_Text NameText;
        [SerializeField] private TMP_Text CountText;
        [SerializeField] private IntRefValue SellCount;
//------Private Variables-------//

#region UNITY_METHODS

        private void Awake()
        {
            Data.Load();
            UpdateVisual();
            UpdateCountText();
            SellCount.OnValueChanged += UpdateCountText;
        }

        private void OnDestroy()
        {
            SellCount.OnValueChanged -= UpdateCountText;
        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private void UpdateVisual()
        {
            Icon.sprite = Data.GemSprite;
            NameText.text = Data.GameName;
        }

        private void UpdateCountText()
        {
            CountText.text ="Sell Gem Count: "+SellCount.Value;
        }
#endregion
    }
}