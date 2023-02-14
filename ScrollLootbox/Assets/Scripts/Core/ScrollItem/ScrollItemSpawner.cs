using System;
using System.Collections.Generic;
using Configs;
using Core.Randomizer;
using UI;
using UnityEngine;
using Zenject;

namespace Core.ScrollItem
{
    public class ScrollItemSpawner : MonoBehaviour
    {
        public Action<Color> OnSetDropColor;
        
        private List<ScrollItemController> _controllers = new List<ScrollItemController>();
        private ScrollItemController _dropItem;
        private ScrollItemTable _scrollItemTable;
        private ScrollItemPointsSource _pointsSource;
        private Camera _camera;
        private ScrollItemRandomizer _randomizer;

        public List<ScrollItemController> ItemControllers => _controllers;
        public ScrollItemController DropItem => _controllers[^4];

        [Inject]
        public void Init(ScrollItemTable scrollItemTable, ScrollItemPointsSource scrollItemPointsSource,
            Camera mainCamera, ScrollItemRandomizer randomizer)
        {
            _scrollItemTable = scrollItemTable;
            _pointsSource = scrollItemPointsSource;
            _camera = mainCamera;
            _randomizer = randomizer;
        }

        public void Spawn()
        {
            List<Color> itemColors = _randomizer.GetScrollItemColors(_scrollItemTable.ScrollSlots);
            float distanceBetweenItem = _pointsSource.GetDistance();

            int index = 0;
            for (int i = 0; i < _scrollItemTable.ScrollItemAmount / itemColors.Count; i++)
            {
                for (int j = 0; j < itemColors.Count; j++)
                {
                    index++;
                    ScrollItemController scrollItemController = Instantiate(_scrollItemTable.ScrollItemPrefab, transform);
                    scrollItemController.SetView(itemColors[j]);
                    
                    Vector3 point = _camera.ScreenToWorldPoint(_pointsSource.EndPoint.position);
                    scrollItemController.transform.position = new Vector3(point.x - distanceBetweenItem * index, point.y, 0);
                    
                    _controllers.Add(scrollItemController);
                }
            }

            Color color = _randomizer.GetScrollItemColor(_scrollItemTable);
            _controllers[^4].SetView(color);
            OnSetDropColor?.Invoke(color);
        }

        public void Respawn()
        {
            for (int i = _controllers.Count - 1; i >= 0; i--)
            {
                Destroy(_controllers[i].gameObject);
                _controllers.RemoveAt(i);
            }
            
            Spawn();
        }
    }
}