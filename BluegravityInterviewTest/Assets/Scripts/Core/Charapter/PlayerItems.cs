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
        public List<string> CarIds { get; private set; }
        public List<string> InventoryIds { get; private set; }
        public PlayerItems()
        {
            CarIds = new List<string>();
            InventoryIds = new List<string>();
            UpdateCash(500);
        }
        public void UpdateCash(int cash)
        {
            Cash = cash;
            Items.Instance.UpdateCashLabel(Cash);

        }
        internal void UpdateInventory(List<string> itemsIds)
        {
            //if(InventoryIds == null)
            //    InventoryIds = new List<string>(items);
            //else
            //{
            //    items.ForEach(item => { if (!CheckItemInInventory(item)) InventoryIds.Add(item); });
            //}
            InventoryIds.Clear();
            foreach (var id in itemsIds)
            {
                if(!InventoryIds.Contains(id))
                InventoryIds.Add(id);
            }
            Items.Instance.SetInventoryLabel(Player.PlayerItems.InventoryIds.Count);

        }
        internal void UpdateCar(List<string> itemsIds)
        {
            CarIds.Clear();
            foreach (var id in itemsIds)
            {
                if(!CarIds.Contains(id))
                    CarIds.Add(id);
            }
            Items.Instance.UpdateCarLabel(CarIds.Count);

        }

        //public bool CheckItemInInventory(ClothingItem item)
        //{
        //    foreach(ClothingItem itemInventory in InventoryIds) 
        //    {
        //        if(itemInventory.ID == item.ID)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

    }
}
