using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
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
        public void UpdateCarLabel(int cash)
        {
            _carCount.text = cash.ToString();
        }
        public void SetInventoryLabel(int inventory)
        {
            _inventory.text = inventory.ToString();
        }

        internal void UpdateCashLabel(int count)
        {
            _cashCount.text = count.ToString();
        }
    }
}
