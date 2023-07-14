using System.Collections.Generic;

namespace BluegravityInterviewTest.Core
{
    public class ShopItems
    {
        public static Dictionary<string, int> ShopItemsDict { get { return GetShopItems(); } }
        private static Dictionary<string, int> GetShopItems()
        {
            Dictionary<string, int> shopItems = new Dictionary<string, int>();
            var clothes = ClothingList.GetClotingList();
            for (int i = 0, o = 5; i < clothes.Count; i++, o += 5)
            {
                shopItems[clothes[i].Id] = clothes[i].Price;
            }
            return shopItems;
        }
    }
}
