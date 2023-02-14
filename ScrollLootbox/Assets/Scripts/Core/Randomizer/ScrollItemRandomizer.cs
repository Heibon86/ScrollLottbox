using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

namespace Core.Randomizer
{
    public class ScrollItemRandomizer
    {
        public List<Color> GetScrollItemColors(List<ScrollSlot> slots)
        {
            List<Color> colors = new List<Color>();

            System.Random random = new System.Random();
            for (int i = 0; i < slots.Count; i++)
            {
                for (int j = 0; j < slots[i].Amount; j++)
                {
                    colors.Add(slots[i].Setting.Color);
                }
            }

            var shuffledColors = colors.OrderBy(_ => random.Next()).ToList();

            return shuffledColors;
        }

        public Color GetScrollItemColor(ScrollItemTable scrollItemTable)
        {
            Color color = Color.gray;
            
            float maxRange = 0;
            for (int  i = 0; i < scrollItemTable.ScrollSlots.Count; i++)
            {
                maxRange += scrollItemTable.ScrollSlots[i].Setting.DropChance;
            }
            var randomValue = Random.Range(0, maxRange);

            float topValue = 0;
            for (int  i = 0; i < scrollItemTable.ScrollSlots.Count; i++)
            {
                topValue += scrollItemTable.ScrollSlots[i].Setting.DropChance;
                
                if (randomValue < topValue)
                {
                    color =  scrollItemTable.ScrollSlots[i].Setting.Color;
                    break;
                }
            }

            return color;
        }
    }
}