using IdentityXmlContext.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IdentityXmlContext.Data.FileProviders
{
   public class XMLProvider : XDocumentProvider
    {
       
       public XMLProvider()
       {
          
           FileName = Constants.DATA_FILE_PATH + Constants.DIRECTOTY_SEPARATOR + Constants.USERS_FILE_NAME;
           
       }
       public override XDocument CreateNewDocument( )
       {
           
           XDocument doc = XDocument.Load(Constants. DATA_FILE_PATH + "//" + FileName);
           return doc;
           
       }

       

       
    }
}
