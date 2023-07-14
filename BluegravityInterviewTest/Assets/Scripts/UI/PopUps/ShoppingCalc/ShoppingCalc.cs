using BluegravityInterviewTest.Core;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
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
                    if (price > Player.PlayerData.Cash)
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
                tab.LeanScaleY(1, 0.3f);
                tab.gameObject.GetComponent<ShoppingCalcTab>().Active(false);
            }
            _buttonsList.ForEach(button => { button.gameObject.SetActive(false); });
            shoppingCalcTab.Active(true);
            shoppingCalcTab.transform.LeanScaleY(0.9f, 0.3f);
            _index = shoppingCalcTab.transform.GetSiblingIndex();
            _buttons.GetChild(_index).gameObject.SetActive(true);
            UpdateContent();
        }
        private void UpdateContent()
        {
            _clothingSelector.ClearContent();
            if (_index < 1)
            {
                foreach (var item in Player.PlayerData.CarIds)
                {
                    _clothingSelector.CreateItem(item, true);

                }
            }
            else
            {
                foreach (var item in Player.PlayerData.InventoryIds)
                {
                    _clothingSelector.CreateItem(item, true);

                }
            }
            if (_clothingSelector.Items.Count == 0) _clothingSelector.ShowMessage("There aren't items here");

            // else Fill with inventory things

        }
        public void SellTrigger()
        {
            int price = int.Parse(_totalPrice.text);
            int newCash = Player.PlayerData.Cash + price;
            List<string> invetoryItems = new List<string>(Player.PlayerData.InventoryIds);
            foreach (string item in _clothingSelector.SelectedItems)
            {
                invetoryItems.Remove(item);
            }
            string[] defaults = { Player.PlayerData.UpperClothingId, Player.PlayerData.BottomClothingId };
            for (int i = 0; i < defaults.Length; i++)
            {
                if (_clothingSelector.SelectedItems.Contains(defaults[i]))
                {
                    defaults[i] = "default";
                }
            }
            Player.PlayerData.SetClothing(defaults[0], defaults[1]);
            var clothingShop = GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingShop>();
            clothingShop.UpdateCash(newCash);
            clothingShop.UpdateInventory(invetoryItems);
            UpdateContent();

        }
        public void BuyTrigger()
        {
            List<string> carItems = new List<string>(Player.PlayerData.CarIds);
            List<string> invetoryItems = new List<string>(Player.PlayerData.InventoryIds);
            int price = int.Parse(_totalPrice.text);
            int newCash = Player.PlayerData.Cash - price;
            foreach (string item in _clothingSelector.SelectedItems)
            {
                invetoryItems.Add(item);
                carItems.Remove(item);
            }
            var clothingShop = GameObject.FindGameObjectWithTag("ClothingShop").GetComponent<ClothingShop>();
            clothingShop.UpdateCash(newCash);
            clothingShop.UpdateInventory(invetoryItems);
            clothingShop.UpdateCar(carItems);
            UpdateContent();
        }

    }
}
