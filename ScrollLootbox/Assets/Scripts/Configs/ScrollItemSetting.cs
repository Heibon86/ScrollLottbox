using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ScrollItemSetting", menuName = "Configs/ScrollItemSetting")]
    public class ScrollItemSetting : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _color;
        [SerializeField] private float _dropChance;

        public Color Color => _color;
        public float DropChance => _dropChance;
    }
}