using BluegravityInterviewTest.Core;
using BluegravityInterviewTest.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class Pickups : PopUp
    {

        [SerializeField] private Button _updateButton;
        [SerializeField] private ClothingSelector _clothingSelector;

        private void OnEnable()
        {
            ShowItems();
        }

        private void ShowItems()
        {
            _clothingSelector.ClearContent();
            foreach (var item in ShopItems.ShopItemsDict)
            {
                _clothingSelector.CreateItem(item.Key, true);

            }

            if (_clothingSelector.Items.Count == 0) _clothingSelector.ShowMessage("There aren't items here");
            else
            {
                foreach (var item in _clothingSelector.Items)
                {
                    if (Player.PlayerData.InventoryIds.Contains(item.ID))
                    {
                        item.SetEnable(false);
                    }
                }
            }
        }

        public void UpdateTrigger()
        {
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingShop>().UpdateCar(_clothingSelector.SelectedItems);
        }
        private void Update()
        {
            _updateButton.interactable = !_clothingSelector.SelectedItems.ToHashSet().SetEquals(Player.PlayerData.CarIds.ToHashSet());
        }
    }
}
