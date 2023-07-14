using BluegravityInterviewTest.Core;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class InventoryClothes : PopUp
    {
        [SerializeField] private Button _selectButton;
        [SerializeField] private ClothingSelector _clothingSelectorUpper, _clothingSelectorBottom;
        void OnEnable()
        {
            ShowItems();
        }

        private void ShowItems()
        {
            _clothingSelectorUpper.ClearContent();
            _clothingSelectorBottom.ClearContent();
            foreach (var item in ClothingList.GetClotingList())
            {
                if (Player.PlayerData.InventoryIds.Contains(item.Id))
                {
                    if (item.Type.Equals("upper"))
                        _clothingSelectorUpper.CreateItem(item.Id, false);
                    if (item.Type.Equals("bottom"))
                        _clothingSelectorBottom.CreateItem(item.Id, false);
                }
            }
            if (_clothingSelectorUpper.Items.Count == 0) _clothingSelectorUpper.ShowMessage("There aren't items here");
            if (_clothingSelectorBottom.Items.Count == 0) _clothingSelectorBottom.ShowMessage("Go to the clothingshop");
        }
        public void SelectClotheTrigger()
        {
            string upperId = _clothingSelectorUpper.SelectedItems.Count > 0 ? _clothingSelectorUpper.SelectedItems.ToArray()[0] : "default";
            string bottomId = _clothingSelectorBottom.SelectedItems.Count > 0 ? _clothingSelectorBottom.SelectedItems.ToArray()[0] : "default";
            Player.PlayerData.SetClothing(upperId, bottomId);
        }

        private void Update()
        {
            _selectButton.interactable = false;
            string upperSelected = "default";
            string bottomSelected = "default";
            if (_clothingSelectorUpper.SelectedItems.Count > 0) upperSelected = _clothingSelectorUpper.SelectedItems[0];
            if (_clothingSelectorBottom.SelectedItems.Count > 0) bottomSelected = _clothingSelectorBottom.SelectedItems[0];

            if (!Player.PlayerData.UpperClothingId.Equals(upperSelected) || !Player.PlayerData.BottomClothingId.Equals(bottomSelected))
            {
                _selectButton.interactable = true;
            }

        }
    }
}
