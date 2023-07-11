using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.UI
{
    public class PopUp : MonoBehaviour
    {
        internal void Show()
        {
            gameObject.LeanScale(Vector3.one, .4f);
        }
        internal void Hide()
        {
            gameObject.LeanScale(Vector3.zero, .4f);
        }

        protected virtual void ItemHander(ClothingItem item) { }

        public void ItemTrigger(ClothingItem item)
        {
            ItemHander(item);
        }
    }
}
