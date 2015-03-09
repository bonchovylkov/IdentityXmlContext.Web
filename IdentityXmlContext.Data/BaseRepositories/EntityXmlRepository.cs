using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdentityXmlContext.Data
{
    public abstract class EntityXmlRepository<T> : XmlRepositoryBase<T>
    {
        #region cache control

        private XElement parentElement;
        private XName xName;

        protected EntityXmlRepository(XName entityName,XDocumentProvider provider)
            : base(entityName, provider)
        {
        }

        public override XElement ParentElement
        {
            get
            {
                // returns in memory element or get it from file
                return parentElement ?? (parentElement = GetParentElement());
            }
            protected set
            {
                parentElement = value;
            }
        }

        /// <summary>
        /// Gets the parent element for this node type
        /// </summary>
        protected abstract XElement GetParentElement();
        #endregion
    }
}
