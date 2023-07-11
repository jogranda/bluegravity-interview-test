using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.UI
{
    public class DiagBoxes : MonoBehaviour
    {
        [SerializeField] private GameObject _diagBoxSource;
        [SerializeField] private Transform _container;
        public static DiagBoxes Instance;

        private void Awake()
        {
             Instance = this;
        }
        public GameObject Create(string message, Sprite sprite = null)
        {
            GameObject diagBox = Instantiate(_diagBoxSource, _container);
            diagBox.GetComponent<DiagBox>().Show(message, sprite);
            return diagBox;
        }
    }
}
