using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdentityXmlContext.Data
{
    public abstract class ChildEntityXmlRepository<T> : XmlRepositoryBase<T>
    {
        private object currentParentId;
        private object lastParentId;

        private XElement parentElement;

        public override XElement ParentElement
        {
            get
            {
                if (parentElement == null)
                {
                    parentElement = GetParentElement(currentParentId);
                    lastParentId = currentParentId;
                }
                return parentElement;
            }
            protected set
            {
                parentElement = value;
            }
        }

        /// <summary>
        /// Defines wich parent entity is active
        /// when this property changes, the parent element field is nuled, forcing the parent element to be updated
        /// </summary>
        protected object CurrentParentId
        {
            get
            {
                return currentParentId;
            }
            set
            {
                currentParentId = value;
                if (value != lastParentId)
                {
                    parentElement = null;
                }
            }
        }



        protected ChildEntityXmlRepository(XName entityName,XDocumentProvider provider) : base(entityName, provider) { }

        protected abstract XElement GetParentElement(object parentId);

        protected abstract object GetParentId(T entity);


        public override IEnumerable<T> GetAll(object parentId)
        {
            CurrentParentId = parentId;
            return ParentElement.Elements(ElementName).Select(Selector);
        }

        public override void Insert(T entity, bool persistir = true)
        {
            CurrentParentId = GetParentId(entity);
            base.Insert(entity, persistir);
        }

        public override void Update(T entity, bool persistir = true)
        {
            CurrentParentId = GetParentId(entity);
            base.Update(entity, persistir);
        }

        public override void Delete(T entity, bool persistir = true)
        {
            CurrentParentId = GetParentId(entity);
            base.Delete(entity, persistir);
        }
    }
}
