using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class Clothing
    {
        public string Id { get; private set; }
        public int Price { get; private set; }
        public string Type { get; private set; }
        public Color Color { get; private set; }
        public Clothing(string id, int price, string type, Color color)
        {
            Id = id;
            Price = price;
            Type = type;
            Color = color;
        }
    }
}
