using System;
using TMPro;
using UnityEngine;

namespace Balance
{
    public class BalanceText : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private TMP_Text Text;
//------Private Variables-------//

#region UNITY_METHODS

        private void Awake()
        {
            BalanceManager.OnBalanceChange += UpdateText;
        }

        private void OnEnable()
        {
            UpdateText();
        }

        private void OnDisable()
        {
            BalanceManager.OnBalanceChange -= UpdateText;
        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private void UpdateText()
        {
            Text.SetText(TextWithMoneyFormat(BalanceManager.CurrentBalance));
        }

        private string TextWithMoneyFormat(int balance)
        {
            if (balance >= int.MaxValue)
                return "INF";

            var formatBalance = Mathf.FloorToInt(Mathf.Log10(balance) + 1);
            return formatBalance switch
            {
                <= 4 => balance.ToString(),
                <= 6 => $"{balance / 1000f:F1}K",
                <= 9 => $"{balance / 1000000f:F1}M",
                _ => $"{balance / 1000000000f:F1}B"
            };
        }
#endregion

    }
}