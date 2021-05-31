using Dapper;
using Dapper.Contrib.Extensions;
using Entites;
using InventoryRepository.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryRepository
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        private IOptions<Appsettings> _appSettings;
        private Interfaces.IItemRepository _ItemRepository;

        public ItemRepository(IOptions<Appsettings> appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
            _ItemRepository = new ItemRepository(appSettings);
        }

        public Item AddItem(Item item)
        {
            try
            {
                SqlMapperExtensions.Insert(con, item);
                return item;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteItem(Item item)
        {
            try
            {
                return SqlMapperExtensions.Update(con, item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Item> GetAllItem(int ItemID = 0)
        {
            try
            {
                string query = " select * from inventory where isActive = 1";

                if(ItemID > 0)
                {
                    query += " and itemid = " + ItemID;
                }

                var ItemList = SqlMapper.Query<Item>(con, query).ToList();

                return ItemList;
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
                 SqlMapperExtensions.Update(con, item);
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
