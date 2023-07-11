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
        public static Items Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
        }
        public void SetCash(int cash)
        {
            _carCount.text = cash.ToString();
        }
        public void SetCar(int cash)
        {
            _carCount.text = cash.ToString();
        }
    }
}
