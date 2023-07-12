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
    public class ClothingSelector : MonoBehaviour
    {
        [SerializeField] private List<string> _selectedItems;
        [SerializeField] private List<string> _items;
        [SerializeField] private GameObject _cloathingItemSource;
        [SerializeField] private Transform _content;
        private bool _filling ;
        public List<string> SelectedItems { get { return _selectedItems; } }

        private void OnEnable()
        {
            _selectedItems = new List<string>();
            //_items = new List<ClothingItem>();
        }
        public void ItemTrigger(ClothingItem item)
        {
            Debug.Log("ItemTrigger");
            if (_selectedItems.Contains(item.ID))
                _selectedItems.Remove(item.ID);
            else _selectedItems.Add(item.ID);
        }
        //private IEnumerator Fill(List<ClothingItem> clothingItems)
        //{
        //    Debug.Log("Fill called");
        //    ClearContent();
        //    yield return new WaitUntil(() => _content.childCount == 0 && !_filling);
        //    _filling = true;
        //    foreach (ClothingItem item in clothingItems)
        //    {
        //        if (item != null)
        //        {
        //            Instantiate(item, _content);
        //        }
        //    }
        //    _filling = false;
        //}
        public void CreateItem(string id, bool isForSell = false)
        {
            var item = Instantiate(_cloathingItemSource, _content).GetComponent<ClothingItem>();
            item.Set(id, isForSell);
            _items.Add(item.ID);
        }

        public void ClearContent()
        {
            _selectedItems = new List<string>();
            foreach (Transform item in _content)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
