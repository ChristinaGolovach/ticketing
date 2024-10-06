namespace Modules.Orders.Data
{
    public static class OrdersDBConstants
    {
        public static readonly string SchemaName = "orders";
        public static readonly string DBConnectionKey = "Database";

        public static class OrderTable
        {
            public static readonly string TableName = "Orders";
        }

        public static class OrderItemTable
        {
            public static readonly string TableName = "OrderItems";
        }
    }
}
