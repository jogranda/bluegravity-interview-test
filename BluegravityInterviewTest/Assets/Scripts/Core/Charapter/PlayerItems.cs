using BluegravityInterviewTest.UI;
using BluegravityInterviewTest.UI.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.Core.Charapter
{
    public class PlayerItems
    {
        public int Cash { get; private set; }
        public List<ClothingItem> Car { get; private set; }
        public List<object> Inventory { get; private set; }
        public PlayerItems()
        {
            Car = new List<ClothingItem>();
            Inventory = new List<object>();
            SetCash(500);
        }
        public void AddToInventory(ClothingItem item)
        {
            Inventory.Add(item);
        }

        public void RemoveFromInventory(ClothingItem item)
        {
            if(Inventory.Contains(item))
                Inventory.Remove(item);
        }
        public void SetCash(int cash)
        {
            Cash = cash;
        }

        internal void UpdateCar(List<ClothingItem> items)
        {
            Car = new List<ClothingItem>(items);;
        }
    }
}
