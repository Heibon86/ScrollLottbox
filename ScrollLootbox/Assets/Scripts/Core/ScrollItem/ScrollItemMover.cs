using System;
using Configs;
using DG.Tweening;
using UI;
using UnityEngine;
using Zenject;

namespace Core.ScrollItem
{
    public class ScrollItemMover
    {
        public Action<float> OnEndMove;
        
        private ScrollItemSpawner _scrollItemSpawner;
        private ScrollItemTable _scrollItemTable;
        private ScrollItemPointsSource _pointsSource;
        private Camera _camera;

        [Inject]
        public void Init(ScrollItemSpawner scrollItemSpawner, ScrollItemTable scrollItemTable, 
            ScrollItemPointsSource scrollItemPointsSource, Camera mainCamera)
        {
            _scrollItemSpawner = scrollItemSpawner;
            _scrollItemTable = scrollItemTable;
            _pointsSource = scrollItemPointsSource;
            _camera = mainCamera;
        }

        public void PlayScroll()
        {
            for (int i = 0; i < _scrollItemSpawner.ItemControllers.Count; i++)
            {
                Vector3 targetPoint = _camera.ScreenToWorldPoint(_pointsSource.CentralPoint.position);
                float distance = Vector3.Distance(_scrollItemSpawner.DropItem.transform.position, targetPoint);

                ScrollItemController scrollItemController = _scrollItemSpawner.ItemControllers[i];
                Action action = null;
                
                if (scrollItemController == _scrollItemSpawner.DropItem)
                {
                    void EndMove()
                    {
                        OnEndMove?.Invoke(TimeSpan.FromMilliseconds(_scrollItemTable.ScrollDuration).Seconds);
                    }

                    action = EndMove;
                }
                
                Move(action, scrollItemController, scrollItemController.transform.position.x + distance, _scrollItemTable.ScrollDuration, 
                        _scrollItemTable.SpeedCurve);
            }
        }

        public void Move(Action action, ScrollItemController scrollItemController, float targetPositionX, float duration, AnimationCurve speedCurve)
        {
            scrollItemController.transform.DOMoveX(targetPositionX, duration).SetEase(speedCurve).OnComplete(() =>
            {
                action?.Invoke();
            });;
        }
    }
}