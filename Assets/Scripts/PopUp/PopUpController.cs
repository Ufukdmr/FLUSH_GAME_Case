using DG.Tweening;
using UnityEngine;

namespace PopUp
{
    public class PopUpController : MonoBehaviour
    {
//-------Public Variables-------//

//------Serialized Fields-------//

//------Private Variables-------//

#region UNITY_METHODS

#endregion


#region PUBLIC_METHODS

        public void OpenPopUp()
        {
            gameObject.SetActive(true);
            transform.DOScale(Vector3.one, .2f).SetEase(Ease.OutQuad);
        }

        public void ClosePopUp()
        {
            transform.DOScale(Vector3.zero, .2f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
#endregion


#region PRIVATE_METHODS

#endregion
        
    }
}