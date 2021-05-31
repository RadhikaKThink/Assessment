using Entites;
using System;
using System.Collections.Generic;

namespace InventoryBusiness.Interfaces
{
    public interface IItemBusiness
    {
        Item AddItem(Item item);

        Item UpdateItem(Item item);

        List<Item> GetAllItem(int ItemID = 0);

        bool DeleteItem(int ItemID);
    }
}
