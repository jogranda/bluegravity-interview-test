using UnityEngine;

namespace BluegravityInterviewTest.UI
{
    public class ActionBoxes : MonoBehaviour
    {
        [SerializeField] private GameObject _actionBoxSource;
        [SerializeField] private Transform _container;
        public static ActionBoxes Instance;
        private void Awake()
        {
            Instance = this;
        }

        public GameObject Create(string message, float duraction = 0)
        {
            GameObject ActionBox = Instantiate(_actionBoxSource, _container);
            ActionBox.GetComponent<ActionBox>().Show(message, duraction);
            return ActionBox;
        }
    }
}
