using Assets.Scripts.RPGame.Core.Data;
using System.Collections.Generic;

namespace Assets.Scripts.RPGame.Core.Game
{
    public enum rpItemType { INVALID = -1, COUNT }
    public class rpItemList : Dictionary<rpItemType, rpItem>
    {
        public void AddItem(rpItemType type, rpItem item) { Add(type, item); }
        //public void AddItem(int type, rpItem skill) { Add((DataType.Item) type, skill); }
    }
    public class rpItem
    {
        public rpItem()
        {

        }
    }
}
