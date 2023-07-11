using BluegravityInterviewTest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BluegravityInterviewTest.Core.Charapter
{
    public class Buyer : MonoBehaviour
    {
        private DiagBox _currentDiagBox;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                _currentDiagBox = DiagBoxes.Instance.Create("Quieres comprar algo?" , GetComponent<SpriteRenderer>().sprite).GetComponent<DiagBox>();
            } else
            {

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
    }
}
