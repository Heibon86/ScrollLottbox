using UnityEngine;

namespace Core.ScrollItem
{
    public class ScrollItemView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}