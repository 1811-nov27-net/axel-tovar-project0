using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.UI

{
    public static class SecretConfiguration
    {
        public static readonly string ConnectionString = "Server=tcp:tovar-server.database.windows.net,1433;Initial Catalog=PizzaStoreDB;Persist Security Info=False;" +
                "User ID=axel;Password=6372140At;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=10;";
    }
}
