using System;
using Balance;
using DG.Tweening;
using Gems;
using Lean.Pool;
using UnityEngine;
using Value;

namespace StackMechanic
{
    public class GemSeller : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//
        [SerializeField] private PLayerStackArea StackArea;
        [SerializeField] private float SellRate = .1f;
//------Private Variables-------//
        private GemSellArea _currentSellArea;

#region UNITY_METHODS

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out GemSellArea area))
                return;
            _currentSellArea = area;
            if (StackArea.IsEmpty)
                return;
            StartSell();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out GemSellArea area))
                return;
            if (area != _currentSellArea)
                return;
            _currentSellArea = null;
            StopSell();
        }

#endregion


#region PUBLIC_METHODS

#endregion


#region PRIVATE_METHODS

        private void StartSell()
        {
            var gem = StackArea.GetLatestGemFromArea();
            SellGem(gem);
        }

        private void StopSell()
        {
        }

        private void SellGem(GemController gem)
        {
            StackArea.RemoveGemFromList(gem);
            gem.transform.SetParent(_currentSellArea.transform);
            gem.MoveToTargetPosition(0, () =>
            {
                var incomeGold = Mathf.FloorToInt(gem.Data.BaseSellPrice * gem.transform.localScale.y*100);
                BalanceManager.AddToBalance(incomeGold);
                gem.Data.SellGem();
                LeanPool.Despawn(gem);
            });
            DOVirtual.DelayedCall(SellRate, () =>
            {
                if (_currentSellArea == null)
                    return;
                StartSell();
            });
        }

#endregion
    }
}