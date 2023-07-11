using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class ClothingItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image _hover;
        private bool _active;
        public void OnPointerDown(PointerEventData eventData)
        {
            transform.LeanScale(Vector3.one * .9f, .3f);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            transform.LeanScale(Vector3.one, .3f);
            OnTrigger();
        }
        public void OnTrigger()
        {
            _active = !_active;
            _hover.gameObject.SetActive(_active);
            transform.GetComponentInParent<PopUp>().ItemTrigger(this);
        }
    }
}
