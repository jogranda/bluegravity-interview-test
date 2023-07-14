using BluegravityInterviewTest.UI;
using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class Buyer : MonoBehaviour
    {
        private DiagBox _currentDiagBox;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                _currentDiagBox = DiagBoxes.Instance.Create("Do you want to buy/sell?", GetComponent<SpriteRenderer>().sprite).GetComponent<DiagBox>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                if (_currentDiagBox != null)
                    _currentDiagBox.Hide();
            }
        }
    }
}
