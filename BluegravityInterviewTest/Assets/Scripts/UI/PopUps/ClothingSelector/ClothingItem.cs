using BluegravityInterviewTest.Core.Charapter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class ClothingItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image _indicator;
        [SerializeField] private TMP_Text _priceLabel;
        private ClothingSelector _clothingSelector;
        private string _id;
        private int _price;
        private bool _interactable;
        public string ID { get { return _id; } }
        public int Price { get { return _price; } }
        private bool _active, _isForSell;

        private void Awake()
        {
            _clothingSelector = transform.GetComponentInParent<ClothingSelector>();
        }
        public void Set(string id, bool isForSell)
        {
            _id = id;
            _price = ShopItems.ShopItemsDict[_id];
            _isForSell = isForSell;
            _interactable = true;
            if (Player.PlayerItems.CarIds.Contains(ID) && !isForSell)
            {
                OnTrigger();
                //_indicator.color = new Color(0.325f, 0.576f, 0.341f, 0.4745098f);
            }

            //if(_isForSell)
            //{
            //    _price = _price / 2;
            //}
            _priceLabel.text = _price.ToString();
        }
        private void Update()
        {
            _indicator.gameObject.SetActive(false);
            if (Player.PlayerItems.InventoryIds.Contains(ID) && !_isForSell)
            {
                _interactable = false;
                _indicator.gameObject.SetActive(true);
                _indicator.color = new Color(0, 0, 0, 0.3f);
            }
            if (_clothingSelector.SelectedItems.Contains(ID))
            {
                _indicator.gameObject.SetActive(true);
                _indicator.color = new Color(0.325f, 0.576f, 0.341f, 0.4745098f);
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if(_interactable)
            transform.LeanScale(Vector3.one * .9f, .3f);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if(_interactable)
            {
                transform.LeanScale(Vector3.one, .3f);
                OnTrigger();
            }
        }
        public void OnTrigger()
        {
            _active = !_active;
            _clothingSelector.ItemTrigger(this);
        }
    }
}
