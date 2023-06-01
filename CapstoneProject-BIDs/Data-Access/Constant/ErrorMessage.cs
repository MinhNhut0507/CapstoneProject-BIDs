namespace Data_Access.Constant
{
    public static class ErrorMessage
    {
        #region Common error message
        public static class CommonError
        {
            public readonly static string NAME_IS_NULL = "Name request is null";
            public readonly static string ID_IS_NULL = "ID request is null";
            public readonly static string INVALID_REQUEST = "Request is not valid";
            public readonly static string ACCOUNT_NAME_IS_EXITED = "Account name is exited";
            public readonly static string EMAIL_IS_EXITED = "Email is exited";
            public readonly static string CCCD_NUMBER_IS_EXITED = "CCCD number is exited";
            public readonly static string PHONE_IS_EXITED = "Phone is exited";
        }
        #endregion

        #region User error message
        public static class UserError
        {
            public readonly static string USER_NOT_FOUND = "User is not existed";
            public readonly static string USER_EXISTED = "User is existed";
        }
        #endregion
    }
}
