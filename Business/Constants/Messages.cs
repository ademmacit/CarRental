using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product has been added succesfully";
        public static string ProductNameInvalid = "Product name is invalid";
        public static string MaintenanceTime = "It is maintenance";
        public static string ProductsListed = "Prducts has been listed";
        public static string SameProductNameError = "Cant add products with same name";
        public static string CheckIfCategoryLimitExeeded = "category limit exeeded";
        public static string AuthorizationDenied = "authorisation denied";

        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password error";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created";
    }
}
