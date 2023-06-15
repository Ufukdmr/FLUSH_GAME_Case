using UnityEngine;

namespace Value
{
    
    [CreateAssetMenu(menuName = "Create RefValue", fileName = "IntRefValue", order = 0)]
    public class IntRefValue : ScriptableObject
    {
        public delegate void ValueChanged();
        public event ValueChanged OnValueChanged;

        private void ValueHasChanged()
        {
            OnValueChanged?.Invoke();
        }
        
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueHasChanged();
            }
        }

        private int _value;
    }
}