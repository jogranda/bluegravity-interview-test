using BluegravityInterviewTest.Core;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class ClothingItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image _indicator, _upperExpo, _bottomExpo;
        [SerializeField] private bool _interactable;
        [SerializeField] private TMP_Text _priceLabel;
        private bool _active, _enable, _showPrice;
        private ClothingSelector _clothingSelector;
        private string _id;
        private int _price;
        private bool IsMine { get { return Player.PlayerData.InventoryIds.Contains(ID); } }
        public string ID { get { return _id; } }
        public int Price { get { return _price; } }

        private void Awake()
        {
            _clothingSelector = transform.GetComponentInParent<ClothingSelector>();
        }
        public void Set(string id, bool showPrice)
        {
            _id = id;
            _price = ShopItems.ShopItemsDict[_id];
            _showPrice = showPrice;
            _interactable = true;
            _enable = true;

            _priceLabel.text = _price.ToString();

            ShowExpo();
            if (id.Equals("default"))
            {
                gameObject.SetActive(false);
                return;
            }

            if (Player.PlayerData.CarIds.Contains(_id) || Player.PlayerData.UpperClothingId.Equals(_id) || Player.PlayerData.BottomClothingId.Equals(_id) && enabled)
            {
                OnTrigger();
            }
        }
        private void ShowExpo()
        {
            var cloth = ClothingList.GetClotingList().FirstOrDefault(cloth => cloth.Id.Equals(ID));
            switch (cloth.Type)
            {
                case "upper":
                    _upperExpo.gameObject.SetActive(true);
                    _upperExpo.color = cloth.Color;
                    break;
                case "bottom":
                    _bottomExpo.gameObject.SetActive(true);
                    _bottomExpo.color = cloth.Color;
                    break;
                default:
                    break;
            }

        }
        private void Update()
        {
            _priceLabel.transform.parent.gameObject.SetActive(_showPrice);
            if (!_enable)
            {
                _interactable = false;
                _indicator.gameObject.SetActive(true);
                _indicator.color = new Color(0, 0, 0, 0.3f);
                return;
            }
            _indicator.color = new Color(0.325f, 0.576f, 0.341f, 0.4745098f);
            _interactable = true;
            _indicator.gameObject.SetActive(_clothingSelector.SelectedItems.Contains(ID));
        }
        public void SetEnable(bool condition)
        {
            _enable = condition;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_interactable)
                transform.LeanScale(Vector3.one * .9f, .3f);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_interactable)
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
