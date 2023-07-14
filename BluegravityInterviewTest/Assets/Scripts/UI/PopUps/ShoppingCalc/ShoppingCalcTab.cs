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
