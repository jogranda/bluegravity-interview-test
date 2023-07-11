using BluegravityInterviewTest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest
{
    public class Wardrobe : MonoBehaviour
    {
        private ActionBox _currentActionBox;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                _currentActionBox = ActionBoxes.Instance.Create("Press space to select clothes").GetComponent<ActionBox>();
                _currentActionBox.SetTrigger(Handler);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                if(_currentActionBox != null)
                _currentActionBox.Hide();
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (_currentActionBox != null)
                    Handler();
            }
        }

        protected virtual void Handler()
        {
            _currentActionBox.transform.LeanScale(Vector3.one * .8f, .5f).setEaseOutBack().setOnComplete(() => { _currentActionBox.Hide(); });
        }

    }
}
