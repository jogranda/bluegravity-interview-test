using BluegravityInterviewTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace BluegravityInterviewTest.UI.Items
{
    public class Items : MonoBehaviour 
    {
        [SerializeField] private TMP_Text _cashCount;
        [SerializeField] private TMP_Text _carCount;
        [SerializeField] private TMP_Text _inventory;
        public static Items Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
        }
        public void UpdateItems()
        {
            _carCount.text = Player.PlayerData.CarIds.Count.ToString();
            _inventory.text = Player.PlayerData.InventoryIds.Count.ToString();
            _cashCount.text = Player.PlayerData.Cash.ToString();
        }
    }
}
