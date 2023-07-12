using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.UI
{
    public class PopUps : MonoBehaviour
    {
        private Dictionary<string,PopUp> _popUps;
        public static PopUps Instance;
        private void Awake()
        {
            Instance = this;
            _popUps = new Dictionary<string, PopUp>();
            foreach (Transform child in transform) 
            {
                _popUps.Add(child.gameObject.name, child.gameObject.GetComponent<PopUp>());
            }
        }
        public void Show(string name)
        {
            //HidePopups();
            if (_popUps.TryGetValue(name, out PopUp popup))
            {
                popup.Show();
            }
        }
        //public void HidePopups()
        //{
        //    foreach (var popUp in _popUps)
        //    {
        //        if (popUp.Value.gameObject.activeSelf)
        //            popUp.Value.Hide();
        //    }

        //}

    }
}
