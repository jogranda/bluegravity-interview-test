using BluegravityInterviewTest.Core;
using BluegravityInterviewTest.Core.Charapter;
using BluegravityInterviewTest.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest
{
    public class ClothingSelector : PopUp
    {
        [SerializeField]private List<ClothingItem> _selectedItems;
        [SerializeField]private Button _updateButton;

        private void OnEnable()
        {
            _selectedItems = new List<ClothingItem>();
        }
        private void Update()
        {
            //if (_selectedItems.SequenceEqual(Player.PlayerItems.Car) )
            _updateButton.interactable = !_selectedItems.ToHashSet().SetEquals(Player.PlayerItems.Car.ToHashSet());
        }
        protected override void ItemHander(ClothingItem item)
        {
            base.ItemHander(item);
            if (_selectedItems.Contains(item))
                _selectedItems.Remove(item);
            else _selectedItems.Add(item);
        }
        public void UpdateSelectedItems()
        {
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingShop>().UpdateItems(_selectedItems);
        }
    }
}
