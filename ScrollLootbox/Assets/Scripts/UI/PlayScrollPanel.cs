using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayScrollPanel : MonoBehaviour
    {
        public Action OnPlayScroll;
        
        [SerializeField] private Button _playButton;
        
        public void Initialization()
        {
            _playButton.onClick.AddListener(()=>
            {
                OnPlayScroll?.Invoke();
            });
        }

        public void SetEnabledButton(bool isEnabled)
        {
            _playButton.enabled = isEnabled;
        }
    }
}