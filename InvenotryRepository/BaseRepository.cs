using Entites;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;


namespace InventoryRepository
{
    public class BaseRepository : IDisposable
    {

        protected IDbConnection con;
        protected IOptions<Appsettings> _appSettings;

        public BaseRepository(IOptions<Appsettings> appSettings)
        {
            _appSettings = appSettings;
            string connectionString = _appSettings.Value.InventoryDB;
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
