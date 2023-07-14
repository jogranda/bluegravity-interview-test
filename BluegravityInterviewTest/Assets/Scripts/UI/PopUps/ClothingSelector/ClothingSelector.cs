using BluegravityInterviewTest.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class ClothingSelector : MonoBehaviour
    {
        [SerializeField] private List<string> _selectedItems;
        [SerializeField] private GameObject _cloathingItemSource;
        [SerializeField] private TMP_Text _message;
        [SerializeField] private Transform _content;
        [SerializeField] private bool _selectionMultiple;
        public List<string> SelectedItems { get { return _selectedItems; } }
        public List<ClothingItem> Items { get; private set; }

        //private void OnEnable()
        //{
        //    Debug.Log("OnEnable called");
        //    _selectedItems = new List<string>();
        //    Items = new List<ClothingItem>();
        //}
        public void ShowMessage(string message)
        {
            _message.text = message;
            _message.gameObject.SetActive(true);
        }
        public void ItemTrigger(ClothingItem item)
        {
            if(_selectionMultiple)
            {
                if (_selectedItems.Contains(item.ID))
                    _selectedItems.Remove(item.ID);
                else _selectedItems.Add(item.ID);
            } else
            {
                if (_selectedItems.Contains(item.ID))
                {
                    _selectedItems.Clear();
                    return;
                }
                _selectedItems.Clear();
                _selectedItems.Add(item.ID);
            }
        }
        public void CreateItem(string id, bool showPrice = false)
        {
            var item = Instantiate(_cloathingItemSource, _content).GetComponent<ClothingItem>();
            item.Set(id, showPrice);
            Items.Add(item);
        }

        public void ClearContent()
        {
            _selectedItems = new List<string>();
            Items = new List<ClothingItem>();
            _message.text = string.Empty;
            foreach (Transform item in _content)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
