using BluegravityInterviewTest.UI;
using BluegravityInterviewTest.UI.Items;
using BluegravityInterviewTest.Core.Charapter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BluegravityInterviewTest.Core
{
    public class ClothingShop : Build
    {
        internal override void EnterBuild() 
        {
            base.EnterBuild();
            SceneManager.LoadScene(1);
            UpdateCarItem();
        }

        private void UpdateCarItem()
        {
            Items.Instance.SetCar(Player.PlayerItems.Car.Count);
        }

        public void UpdateItems(List<ClothingItem> items)
        {
            Debug.Log("ASASS");
            Player.PlayerItems.UpdateCar(items);
            UpdateCarItem();
        }
    }
}
