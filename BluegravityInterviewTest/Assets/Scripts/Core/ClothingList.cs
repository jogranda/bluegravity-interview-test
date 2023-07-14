using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest.Core
{
    public class ClothingList
    {
        private static List<Clothing> list;
        public static List<Clothing> GetClotingList()
        {
            if (list == null)
            {
                list = new List<Clothing>()
                {
                    new Clothing("default", 0, "upper", new Color(0,0,0,0)),
                    new Clothing("8dfh2", 23, "upper", Color.cyan),
                    new Clothing("jsk72", 34, "upper", Color.red),
                    new Clothing("48gh5", 23, "upper", Color.green),
                    new Clothing("default", 0, "bottom",  new Color(0,0,0,0)),
                    new Clothing("294hf", 54, "bottom", Color.blue),
                    new Clothing("gjk4h", 23, "bottom", Color.yellow),
                    new Clothing("2hfu2", 12, "bottom", Color.black)
                };
            }
            return list;
        }

    }
}
