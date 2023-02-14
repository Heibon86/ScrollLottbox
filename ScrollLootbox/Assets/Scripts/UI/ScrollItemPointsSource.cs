using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ScrollItemPointsSource : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> _points;
        [SerializeField] private RectTransform _endPoint;
        [SerializeField] private RectTransform _centralPoint;

        private Camera _camera;

        public RectTransform EndPoint => _endPoint;
        public RectTransform CentralPoint => _centralPoint;

        [Inject]
        public void Init(Camera mainCamera)
        {
            _camera = mainCamera;
        }

        public float GetDistance()
        {
            Vector3 posFirst = _camera.ScreenToWorldPoint(_points[1].position);
            Vector3 posSecond = _camera.ScreenToWorldPoint(_points[0].position);
            float distance = posFirst.x - posSecond.x;

            return distance;
        }
    }
}
