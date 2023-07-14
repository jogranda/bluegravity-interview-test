using BluegravityInterviewTest.UI;
using BluegravityInterviewTest.UI.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class PlayerData
    {
        public int Cash { get; private set; }
        public List<string> CarIds { get; private set; }
        public List<string> InventoryIds { get; private set; }
        public string UpperClothingId { get; private set; }
        public string BottomClothingId { get; private set; }
        public PlayerData()
        {
            CarIds = new List<string>();
            InventoryIds = new List<string>();
            Cash = 500;
            BottomClothingId = "default";
            UpperClothingId = "default";
        }
        public void UpdateCash(int cash)
        {
            Cash = cash;
            Items.Instance.UpdateItems(); 

        }
        public void SetClothing(string upperId, string bottomId)
        {
            UpperClothingId = upperId;
            BottomClothingId = bottomId;
        }
        internal void UpdateInventory(List<string> itemsIds)
        {
            InventoryIds.Clear();
            foreach (var id in itemsIds)
            {
                if(!InventoryIds.Contains(id) && !id.Equals("default"))
                InventoryIds.Add(id);
            }
            Items.Instance.UpdateItems();

        }
        internal void UpdateCar(List<string> itemsIds)
        {
            CarIds.Clear();
            foreach (var id in itemsIds)
            {
                if(!CarIds.Contains(id))
                    CarIds.Add(id);
            }
            Items.Instance.UpdateItems();

        }
    }
}
