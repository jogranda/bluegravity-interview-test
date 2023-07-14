using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BluegravityInterviewTest.UI
{
    public class ActionBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _messageHolder;
        private void SetDiag(string message)
        {
            _messageHolder.text = message;
        }
        public void Show(string message, float duraction)
        {
            SetDiag(message);
            transform.LeanMoveX(0, .2f).setEaseInSine();
            if (duraction > 0) StartCoroutine("AutoHide", duraction);
        }

        private IEnumerator AutoHide(float secs)
        {
            yield return new WaitForSeconds(secs);
            Hide();
        }

        public void Hide()
        {
            transform.LeanMoveX(-GetComponent<RectTransform>().rect.width, .5f).setEaseInSine().setOnComplete(() => { Destroy(gameObject); });
        }

        internal void SetTrigger(UnityAction handler)
        {
            GetComponent<Button>().onClick.AddListener(handler);
        }
    }
}
