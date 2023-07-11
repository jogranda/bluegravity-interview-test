using BluegravityInterviewTest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest
{
    public class WardrobeShop : Wardrobe
    {
        protected override void Handler()
        {
            base.Handler();
            PopUps.Instance.Show("ClothingSelector");
        }
    }
}
