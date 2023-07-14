using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.UI
{
    public class ShoppingCalcTab : MonoBehaviour
    {
        [SerializeField] private GameObject _indicator;
        internal void Active(bool v)
        {
            _indicator.SetActive(v);
        }
    }
}
