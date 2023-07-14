using BluegravityInterviewTest.UI;
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
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                if (_currentActionBox != null)
                    _currentActionBox.Hide();
            }
        }
    }
}
