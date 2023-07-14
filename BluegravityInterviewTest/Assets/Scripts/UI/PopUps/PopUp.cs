using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField] private Button Close;

        private void Start()
        {
            Close.onClick.AddListener(() => 
            {
                Hide(); 
            });
        }
        internal virtual void Show()
        {
            Close.interactable = false;
            StopAllCoroutines();
            gameObject.SetActive(true);
            gameObject.LeanScale(Vector3.one, .5f).setOnComplete(() => Close.interactable = true);
        }
        internal virtual void Hide()
        {
            gameObject.LeanScale(Vector3.zero, .1f).setOnComplete(() => 
            {
                Close.interactable = true;
                gameObject.SetActive(false);
            });
        }

    }
}
