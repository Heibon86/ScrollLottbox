using UnityEngine;

namespace Core.ScrollItem
{
    public class ScrollItemController : MonoBehaviour
    {
        [SerializeField] private ScrollItemView _view;

        public void SetView(Color color)
        {
            _view.SetColor(color);
        }
    }
}