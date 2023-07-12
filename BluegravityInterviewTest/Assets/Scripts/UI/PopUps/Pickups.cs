using BluegravityInterviewTest.Core;
using BluegravityInterviewTest.Core.Charapter;
using BluegravityInterviewTest.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest
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
                _clothingSelector.CreateItem(item.Key);

            }
        }

        public void UpdateSelectedItems()
        {
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingStore>().UpdateCar(_clothingSelector.SelectedItems);
        }
        private void Update()
        {
            //if (_clothingSelector.SelectedItems.SequenceEqual(Player.PlayerItems.Car))
                _updateButton.interactable = !_clothingSelector.SelectedItems.ToHashSet().SetEquals(Player.PlayerItems.CarIds.ToHashSet());
        }
    }
}
