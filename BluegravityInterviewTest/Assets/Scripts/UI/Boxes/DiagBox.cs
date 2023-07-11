using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class DiagBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _messageHolder;
        [SerializeField] private Image _charapterImageHolder;
        private void SetDiag(string message, Sprite charapterImage = null)
        {
            _messageHolder.text = message;
            if (charapterImage != null)
            {
                _charapterImageHolder.gameObject.SetActive(true);
                _charapterImageHolder.sprite = charapterImage;
            }
            else
                _charapterImageHolder.gameObject.SetActive(false);
        }
        public void Show(string message, Sprite charapterImage)
        {
            SetDiag( message, charapterImage);
            transform.LeanScale(Vector2.one, 1).setEaseOutBack();
        }

        public void Hide()
        {
            transform.LeanScale(Vector2.zero, .3f).setEaseInSine().setOnComplete(() => { Destroy(gameObject); });
        }
    }
}
