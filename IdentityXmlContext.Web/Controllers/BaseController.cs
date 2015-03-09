using IdentityXmlContext.Data;
using IdentityXmlContext.Data.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityXmlContext.Web.Controllers
{
    public class BaseController : Controller
    {
       protected UserRepository userRepository;
      // protected XDocumentProvider provider;

        public BaseController()
        {
            //this.provider = new XMLProvider();

            this.userRepository = new UserRepository(new XMLProvider());
            
        }
       
	}
}