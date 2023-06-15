using System;
using UnityEngine;

namespace Balance
{
    public class BalanceManager : MonoBehaviour
    {
//-------Public Variables-------//
        public static Action OnBalanceChange;
        public static int CurrentBalance { get; set; }
//------Serialized Fields-------//

//------Private Variables-------//
        private const string BALANCE_SAVE_KEY = "Balance_Key";
        
#region UNITY_METHODS

#endregion


#region PUBLIC_METHODS

        public static void AddToBalance(int amount)
        {
            CurrentBalance += amount;
            OnBalanceChange?.Invoke();
        }

#endregion


#region PRIVATE_METHODS

        private void Save()
        {
        }

        private void Load()
        {
        }

#endregion
    }
}