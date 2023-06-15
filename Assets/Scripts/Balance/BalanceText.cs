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
            Text.SetText(BalanceManager.CurrentBalance.ToString());
        }
#endregion

    }
}