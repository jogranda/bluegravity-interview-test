using BluegravityInterviewTest.Core;
using BluegravityInterviewTest.Core.Charapter;
using BluegravityInterviewTest.UI;
using BluegravityInterviewTest.UI.Items;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace BluegravityInterviewTest
{
    public class ShoppingCalc : PopUp
    {
        [SerializeField] private Transform _tabs;
        [SerializeField] private TMP_Text _totalPrice;
        [SerializeField] private Transform _buttons;
        [SerializeField] private ClothingSelector _clothingSelector;
        private List<Button> _buttonsList;

        private int _index;
        private void Awake()
        {
            _buttonsList = new List<Button>();
            foreach (Transform button in _buttons) 
            {
                _buttonsList.Add(button.gameObject.GetComponent<Button>());
            }
        }
        private void Update()
        {
            int price = 0;
            foreach (var itemId in _clothingSelector.SelectedItems)
            {
                price += ShopItems.ShopItemsDict[itemId];
            }
            _totalPrice.text = price.ToString();
            bool condition = false;
            if (_clothingSelector.SelectedItems.Count > 0)
            {
                condition = true;
                if (_index < 1)
                {
                    if(price > Player.PlayerItems.Cash)
                    {
                        condition = false;
                    }
                } 
            }

            _buttonsList[0].interactable = condition;
            _buttonsList[1].interactable = condition;

        }
        //private void OnEnable()
        //{
        //    ShowItems();
        //}

        //private void ShowItems()
        //{
            
        //}
        internal override void Show()
        {
            base.Show();
            TabTrigger(_tabs.GetChild(0).GetComponent<ShoppingCalcTab>());
        }
        public void TabTrigger(ShoppingCalcTab shoppingCalcTab)
        {
            foreach (Transform tab in _tabs) 
            {
                tab.gameObject.GetComponent<ShoppingCalcTab>().Active(false);
            }
            _buttonsList.ForEach(button => { button.gameObject.SetActive(false); });
            shoppingCalcTab.Active(true);
            _index = shoppingCalcTab.transform.GetSiblingIndex();
            _buttons.GetChild(_index).gameObject.SetActive(true);
            UpdateContent();
        }
        private void UpdateContent()
        {
            _clothingSelector.ClearContent();
            if (_index < 1)
            {
                foreach (var item in Player.PlayerItems.CarIds)
                {
                    _clothingSelector.CreateItem(item);

                }
            } else
            {
                foreach (var item in Player.PlayerItems.InventoryIds)
                {
                    _clothingSelector.CreateItem(item, true);

                }
            }
            // else Fill with inventory things

        }
        public void SellTrigger()
        {
            int price = int.Parse(_totalPrice.text);
            int newCash = Player.PlayerItems.Cash + price;
            List<string> invetoryItems = new List<string>(Player.PlayerItems.InventoryIds);
            foreach (string item in _clothingSelector.SelectedItems)
            {
                invetoryItems.Remove(item);
            }
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingStore>().UpdateCash(newCash);
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingStore>().UpdateInventory(invetoryItems);
            UpdateContent();

        }
        public void BuyTrigger()
        {
            List<string> carItems = new List<string>(Player.PlayerItems.CarIds);
            List<string> invetoryItems = new List<string>(Player.PlayerItems.InventoryIds);
            int price = int.Parse(_totalPrice.text);
            int newCash = Player.PlayerItems.Cash - price;
            foreach (string item in _clothingSelector.SelectedItems) 
            {
                invetoryItems.Add(item);
                carItems.Remove(item);
            }
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingStore>().UpdateCash(newCash);
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingStore>().UpdateInventory(invetoryItems);
            GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingStore>().UpdateCar(carItems);
            UpdateContent();
        }

    }
}
