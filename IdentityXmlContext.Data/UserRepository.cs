using IdentityXmlContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IdentityXmlContext.Utils.Enums;
using IdentityXmlContext.Data.FileProviders;
namespace IdentityXmlContext.Data
{
    public class UserRepository : EntityXmlRepository<ApplicationUser>, IRepository<ApplicationUser>
    {
        protected override Func<XElement, ApplicationUser> Selector
        {
            get
            {
                return x => new ApplicationUser()
                {
                    Id = Guid.Parse(x.Element("Id").Value),
                    Username = x.Element("Username").Value,
                    Password = x.Element("Password").Value,
                    
                    
                };
            }
        }

        protected override XElement CreateXElement(ApplicationUser user)
        {
            user.Id = Guid.NewGuid();

            return new XElement(ElementName,
                new XElement("Id", user.Id),
                new XElement("Username", user.Username),
                new XElement("Password", user.Password)
                
                //new XAttribute("Data", user.Data),
                //new XAttribute("Ativo", user.Ativo),
               
            );
        }

        protected override void SetXElementValue(ApplicationUser user, XElement element)
        {
            element.Element("Id").SetValue(user.Id);
            element.Element("Username").SetValue(user.Username);
            element.Element("Password").SetValue(user.Password);


        }


        public UserRepository(XMLProvider provider)
            : base(XmlNames.ApplicationUsers.ToString(), provider)
        {
           // XDocumentProvider.Default = new XMLProvider();
        }

        protected override XElement GetParentElement()
        {
            var doc = DefaultProvider.GetDocument();
            var elements = doc.Elements(XName.Get ( XmlNames.ApplicationUsers.ToString()));
            var el = elements.FirstOrDefault();
            return el;
        }

        protected override object GetEntityId(ApplicationUser user)
        {
            return user.Id;
        }

       
    }
}
