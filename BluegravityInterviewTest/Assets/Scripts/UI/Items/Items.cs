using BluegravityInterviewTest.Core;
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
