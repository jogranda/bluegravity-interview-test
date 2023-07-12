using BluegravityInterviewTest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BluegravityInterviewTest.Core.Charapter
{
    public class Buyer : Charapter
    {
        private DiagBox _currentDiagBox;
        //private bool isHandlered;
        //private bool _triggered;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                _currentDiagBox = DiagBoxes.Instance.Create("Press enter to make a deal" , GetComponent<SpriteRenderer>().sprite).GetComponent<DiagBox>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                if(_currentDiagBox != null)
                _currentDiagBox.Hide();
            }
        }
        //private void FixedUpdate()
        //{
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        if (_currentDiagBox != null && !isHandlered)
        //        {
        //            _triggered = true;
        //            Handler();
        //        }
        //    }

        //    if (_currentDiagBox == null)
        //    {
        //        isHandlered = false;
        //    }
        //}

        //protected void Handler()
        //{
        //    _currentDiagBox.transform.LeanScale(Vector3.one * .8f, .5f).setEaseOutBack().setOnComplete(() => { _currentDiagBox.Hide(); });
        //    PopUps.Instance.Show("ShoppingCalc");
            
        //}
    }
}
