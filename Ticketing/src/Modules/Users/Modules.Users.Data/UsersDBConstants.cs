namespace Modules.Users.Data
{
    public static class UsersDBConstants
    {
        public static readonly string SchemaName = "users";
        public static readonly string DBConnectionKey = "Database";

        public static class UserTable
        {
            public static readonly string TableName = "Users";
            public static readonly int StringMaxLength = 150;
            public static readonly int EmailMaxLength = 50;
        }
    }
}
