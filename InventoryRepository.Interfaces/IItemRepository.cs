using Entites;
using System;
using System.Collections.Generic;

namespace InventoryRepository.Interfaces
{
    public interface IItemRepository
    {
        Item AddItem(Item item);
        Item UpdateItem(Item item);

        List<Item> GetAllItem(int ItemID = 0);

        bool DeleteItem(Item item);
    }
}
