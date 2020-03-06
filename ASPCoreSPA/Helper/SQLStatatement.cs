namespace ASPCoreSPA.Helper
{
    public static class SQLStatatement
    {

        #region User
        public const string UserSigIn = "SELECT Name from [User] WHERE Name = @Name AND Password = @Password";
        #endregion

    }
}