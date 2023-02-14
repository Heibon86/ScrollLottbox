using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DropScrollItemPopup : MonoBehaviour
    {
        public Action OnRestart;
        
        [SerializeField] private Image _itemImage;
        [SerializeField] private Button _restart;

        public void Initialization()
        {
            _restart.onClick.AddListener(() =>
            {
                OnRestart?.Invoke();
            });
        }
        
        public void SetImageColor(Color color)
        {
            _itemImage.color = color;
        }
    }
}