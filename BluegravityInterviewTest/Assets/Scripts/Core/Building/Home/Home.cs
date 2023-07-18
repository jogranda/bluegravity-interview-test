using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class Home : Building
    {
        private void Awake()
        {
            Set(BuildingNames.BuildingNamesList[1].Key, BuildingNames.BuildingNamesList[1].Value);
            EnteringPosition = new Vector2(-1.72f, -1.42f);
            LevingPosition = new Vector2(5.963952f, -1.259098f);
        }
    }
}
