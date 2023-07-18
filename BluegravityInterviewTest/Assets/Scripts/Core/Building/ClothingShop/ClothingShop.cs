using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class ClothingShop : Building
    {
        private void Awake()
        {
            Set(BuildingNames.BuildingNamesList[0].Key, BuildingNames.BuildingNamesList[0].Value);
            EnteringPosition = new Vector2(-1.61f, -1.56f);
            LevingPosition = new Vector2(-13.33897f, 4.947442f);

        }
        internal override void EnterBuild()
        {
            base.EnterBuild();
        }

        internal void UpdateCar(List<string> itemsIds)
        {
            Player.PlayerData.UpdateCar(itemsIds);
        }
        internal void UpdateInventory(List<string> items)
        {
            Player.PlayerData.UpdateInventory(items);
        }

        internal void UpdateCash(int newCash)
        {
            Player.PlayerData.UpdateCash(newCash);
        }
    }
}
