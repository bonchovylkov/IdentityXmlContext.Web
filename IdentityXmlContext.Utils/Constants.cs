using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityXmlContext.Utils
{
   public static class Constants
    {
       public static readonly string USERS_FILE_NAME = "Users.xml";
       public static readonly string DATA_FILE_PATH = BaseHelper.GetDataMapPath();

       public static readonly string DIRECTOTY_SEPARATOR = "//";


        #region Model errors
       public static readonly string MODEL_ERROR_USER_NAME_EXIST_VALUE = "This user name exist!";
       public static readonly string MODEL_ERROR_USER_NAME_DO_NOT_EXIST_VALUE = "The username does not exist!";
       public static readonly string MODEL_ERROR_USER_WRONG_PASS_VALUE = "Incorrect username/password";
       public static readonly string MODEL_ERROR = "MODEL_ERROR"; 

        #endregion

       //public  enum ModelErrorKeys
       //{
       //    UserNameExists,
       //    UserNameDoesNotExist,
       //    WrongPassword,
       //}


    }
}
