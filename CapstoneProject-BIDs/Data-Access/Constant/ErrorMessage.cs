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
            public readonly static string WRONG_EMAIL_FORMAT = "Wrong email format";
            public readonly static string CCCD_NUMBER_IS_EXITED = "CCCD number is exited";
            public readonly static string WRONG_CCCD_NUMBER_FORMAT = "Wrong cccd number format";
            public readonly static string PHONE_IS_EXITED = "Phone is exited";
            public readonly static string WRONG_PHONE_FORMAT = "Wrong phone format";
        }
        #endregion

        #region User error message
        public static class UserError
        {
            public readonly static string USER_NOT_FOUND = "User is not existed";
            public readonly static string USER_EXISTED = "User is existed";
            public readonly static string ACCOUNT_CREATE_NOT_FOUND = "Account create is not existed";
        }
        #endregion

        #region Staff error message
        public static class StaffError
        {
            public readonly static string STAFF_NOT_FOUND = "Staff is not existed";
            public readonly static string STAFF_EXISTED = "Staff is existed";
        }
        #endregion

        #region Role error message
        public static class RoleError
        {
            public readonly static string ROLE_NOT_FOUND = "Role is not existed";
            public readonly static string ROLE_EXISTED = "Role is existed";
        }
        #endregion

        #region Login error message
        public static class LoginError
        {
            public readonly static string WRONG_ACCOUNT_NAME_OR_PASSWORD = "Wrong account name or password";
        }
        #endregion
    }
}
