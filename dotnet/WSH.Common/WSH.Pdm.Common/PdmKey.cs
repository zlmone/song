using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Pdm.Common
{
   public class PdmKey
    {
        public PdmKey()
        {
        }

        string keyId;

        public string KeyId
        {
            get { return keyId; }
            set { keyId = value; }
        }
        string objectID;

        public string ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        int creationDate;

        public int CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        int modificationDate;

        public int ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }
        string modifier;

        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }

        IList<PdmColumn> columns;

        public IList<PdmColumn> Columns
        {
            get { return columns; }
        }

        public void AddColumn(PdmColumn mColumn)
        {
            if (columns == null)
            {
                columns = new List<PdmColumn>();
            }
            columns.Add(mColumn);
        }
    }
}
