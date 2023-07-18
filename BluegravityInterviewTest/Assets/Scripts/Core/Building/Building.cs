using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class Building : MonoBehaviour
    {
        internal virtual void EnterBuild() { }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Vector2 EnteringPosition { get; protected set; }
        public Vector2 LevingPosition { get; protected set; }
        public void Set(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
