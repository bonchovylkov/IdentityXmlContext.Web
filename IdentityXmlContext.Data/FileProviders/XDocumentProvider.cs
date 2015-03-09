using IdentityXmlContext.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdentityXmlContext.Data
{
    public abstract class XDocumentProvider
    {
        // not thread safe yet
        private static bool pendingChanges;

        private bool documentLoadedFromFile;

        FileSystemWatcher fileWatcher;

        //public  XDocumentProvider Default;

        public event EventHandler CurrentDocumentChanged;

        private XDocument loadedDocument;

        public string FileName { get; set; }


        protected XDocumentProvider()
        {
            fileWatcher = new FileSystemWatcher();
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Changed += FileWatcher_Changed;
        }

      private  void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (documentLoadedFromFile && !pendingChanges)
            {
                GetDocument(true);
            }
        }


        /// <summary>
        /// Returns an open XDocument or create a new document
        /// </summary>
        /// <returns></returns>
        public XDocument GetDocument(bool refresh = false)
        {
            if (refresh || loadedDocument == null)
            {
                // we need to refactor it, but just to demonstrate how should work I will send this way ;P
                if (File.Exists(FileName))
                {
                    loadedDocument = XDocument.Load(FileName);
                    documentLoadedFromFile = true;

                    if (fileWatcher.Path != Constants.DATA_FILE_PATH)
                    {
                        fileWatcher.Path = Constants.DATA_FILE_PATH;
                        fileWatcher.Filter = FileName;
                        fileWatcher.EnableRaisingEvents = true;
                    }
                }
                else
                {
                    loadedDocument = CreateNewDocument();
                    fileWatcher.EnableRaisingEvents = false;
                    documentLoadedFromFile = false;
                }

                if (CurrentDocumentChanged != null) CurrentDocumentChanged(this, EventArgs.Empty);
            }

            return loadedDocument;
        }

        /// <summary>
        /// Creates a new XDocument with a determined schemma.
        /// </summary>
        public abstract XDocument CreateNewDocument();

        public void Save()
        {
            if (loadedDocument == null)
                throw new InvalidOperationException();

            try
            {
                // tells the file watcher that he cannot raise the changed event, because his function is to capture external changes.
                pendingChanges = true;
                loadedDocument.Save(FileName);
            }
            finally
            {
                pendingChanges = false;
            }
        }
    }
}
