using Entites;
using InventoryBusiness.Interfaces;
using InventoryRepository;
using InventoryRepository.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryBusiness
{
    public class ItemBusiness : IItemBusiness
    {

        private IOptions<Appsettings> _appSettings;
        private InventoryRepository.Interfaces.IItemRepository _ItemRepository;

        public ItemBusiness(IOptions<Appsettings> appSettings)
        {
            _appSettings = appSettings;
            _ItemRepository = new InventoryRepository.ItemRepository(appSettings);
        }

        public Item AddItem(Item item)
        {
            try
            {
                item.CreatedDate = DateTime.UtcNow;
                item.UpdatedDate = DateTime.UtcNow;

                return _ItemRepository.AddItem(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteItem(int ItemID)
        {
            try
            {
                var Item = _ItemRepository.GetAllItem(ItemID);
                bool _isDeleted = false;

                if (Item?.Count > 0)
                {
                    var item = Item.FirstOrDefault();
                    item.IsActive = false;
                    item.UpdatedDate = DateTime.UtcNow;
                    _isDeleted = _ItemRepository.DeleteItem(item);
                }

                return _isDeleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Item> GetAllItem(int itemID=0)
        {
            try
            {
                var Item = _ItemRepository.GetAllItem(itemID);
                return Item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Item UpdateItem(Item item)
        {
            try
            {

                if (item != null)
                {
                    item.UpdatedDate = DateTime.UtcNow;
                     _ItemRepository.UpdateItem(item);
                }

                return item;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
