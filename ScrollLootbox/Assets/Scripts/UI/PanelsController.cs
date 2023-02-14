using System.Collections;
using Core.ScrollItem;
using UnityEngine;
using Zenject;

namespace UI
{
    public class PanelsController : MonoBehaviour
    {
        [SerializeField] private PlayScrollPanel _playScrollPanel;
        [SerializeField] private DropScrollItemPopup _dropScrollItemPopup;
        [SerializeField] private PlayGamePopup _playGamePopup;

        private ScrollItemMover _scrollItemMover;
        private ScrollItemSpawner _scrollItemSpawner;

        [Inject]
        public void Initialization(ScrollItemMover scrollItemMover, ScrollItemSpawner scrollItemSpawner)
        {
            _scrollItemMover = scrollItemMover;
            _scrollItemSpawner = scrollItemSpawner;
            
            _scrollItemSpawner.OnSetDropColor += SetDropItemViewColor;
            _playScrollPanel.OnPlayScroll += OnPlayScroll;
            _scrollItemMover.OnEndMove += PlayWaitingItemMoveCoroutine;
            _dropScrollItemPopup.OnRestart += OnRestart;
            _playGamePopup.OnPlayGame += OnPlayGame;
            
            _playScrollPanel.Initialization();
            _dropScrollItemPopup.Initialization();
            _playGamePopup.Initialization();
        }

        private void OnPlayGame()
        {
            _scrollItemSpawner.Spawn();
            _playGamePopup.gameObject.SetActive(false);
            _playScrollPanel.gameObject.SetActive(true);
        }

        private void SetDropItemViewColor(Color color)
        {
            _dropScrollItemPopup.SetImageColor(color);
        }
        
        private void OnPlayScroll()
        {
            _scrollItemMover.PlayScroll();
            _playScrollPanel.SetEnabledButton(false);
        }

        private void PlayWaitingItemMoveCoroutine(float seconds)
        {
            StartCoroutine(WaitItemMovingCoroutine(seconds));
        }

        private IEnumerator WaitItemMovingCoroutine(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            ShowDropScrollItemPopup();
        }
        
        private void ShowDropScrollItemPopup()
        {
            _dropScrollItemPopup.gameObject.SetActive(true);
        }
        
        private void OnRestart()
        {
            _scrollItemSpawner.Respawn();
            _dropScrollItemPopup.gameObject.SetActive(false);
            _playScrollPanel.SetEnabledButton(true);
        }

        private void OnDisable()
        {
            _scrollItemSpawner.OnSetDropColor -= SetDropItemViewColor;
            _playScrollPanel.OnPlayScroll -= OnPlayScroll;
            _scrollItemMover.OnEndMove -= PlayWaitingItemMoveCoroutine;
            _dropScrollItemPopup.OnRestart -= OnRestart;
        }
    }
}