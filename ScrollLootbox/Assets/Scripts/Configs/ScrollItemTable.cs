using System.Collections.Generic;
using Core.ScrollItem;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ScrollItemTable", menuName = "Configs/ScrollItemTable")]
    public class ScrollItemTable : ScriptableObject
    {
        [SerializeField] private ScrollItemController _scrollItemPrefab;
        [SerializeField] private int _minScrollItemAmount;
        [SerializeField] private AnimationCurve _speedCurve;
        [SerializeField] private int _scrollItemAmount;
        [SerializeField] private float _scrollDuration;
        [Space(10)]
        [SerializeField] private List<ScrollSlot> _scrollSlots;

        public int MinScrollItemAmount => _minScrollItemAmount;
        public int ScrollItemAmount => _scrollItemAmount;
        public float ScrollDuration => _scrollDuration;
        public AnimationCurve SpeedCurve => _speedCurve;
        public List<ScrollSlot> ScrollSlots => _scrollSlots;
        public ScrollItemController ScrollItemPrefab => _scrollItemPrefab;


        public int GetScrollItemAmount()
        {
            int itemAmount = 0;
            for (int i = 0; i < _scrollSlots.Count; i++)
            {
                itemAmount += _scrollSlots[i].Amount;
            }

            return itemAmount;
        }
    }
}