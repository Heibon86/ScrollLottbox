using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayGamePopup : MonoBehaviour
    {
        public Action OnPlayGame;
        
        [SerializeField] private Button _playButton;
        
        public void Initialization()
        {
            _playButton.onClick.AddListener(() =>
            {
                OnPlayGame?.Invoke();
            });
        }
    }
}