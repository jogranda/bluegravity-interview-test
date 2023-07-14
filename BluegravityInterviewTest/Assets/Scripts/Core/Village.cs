using BluegravityInterviewTest.UI;
using BluegravityInterviewTest.UI.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BluegravityInterviewTest.Core
{
    public class Village : MonoBehaviour
    {
        [SerializeField] private List<Build> _builds;
        [SerializeField] private GameObject _playerSource;
        public static Village Instance;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            //InitializeWorld();
            if (FindObjectOfType<Player>() == null)
            {
                Instantiate(_playerSource);
            }
            Items.Instance.UpdateItems();
            if (!Player.InstructionsShowed)
                StartCoroutine("ShowInstructions");
        }

        private IEnumerator ShowInstructions()
        {
            Player.InstructionsShowed = true;
            yield return new WaitForSeconds(1);
            ActionBoxes.Instance.Create("Move (W, A, S, D)", 3);
            yield return new WaitForSeconds(3);
            ActionBoxes.Instance.Create("Press Shift to sprint", 3);
        }
        public void EnterBuild(Build build)
        {
            if (build.Id == BuildingNames.BuildingNamesList[0].Key)
            {
                SceneManager.LoadScene(1);
            }
            if (build.Id == BuildingNames.BuildingNamesList[1].Key)
            {
                SceneManager.LoadScene(2);
            }

        }
    }
}
