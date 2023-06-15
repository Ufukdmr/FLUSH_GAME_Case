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
        private void Awake()
        {
            Load();
        }

        private void OnDisable()
        {
            Save();
        }
#endregion


#region PUBLIC_METHODS

        public static void AddToBalance(int amount)
        {
            CurrentBalance += amount;
            OnBalanceChange?.Invoke();
        }

        public static void SetBalance(int balance)
        {
            CurrentBalance = balance;
            OnBalanceChange?.Invoke();
        }
#endregion


#region PRIVATE_METHODS

        private void Save()
        {
            PlayerPrefs.SetInt(BALANCE_SAVE_KEY,CurrentBalance);
        }

        private void Load()
        {
            SetBalance(PlayerPrefs.GetInt(BALANCE_SAVE_KEY));
        }

#endregion
    }
}