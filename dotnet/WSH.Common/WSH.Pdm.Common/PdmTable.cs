using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Pdm.Common
{
    public class PdmTable
    {
        public PdmTable()
        {
        }
        string tableId;

        public string TableId
        {
            get { return tableId; }
            set { tableId = value; }
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
        string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        string physicalOptions;

        public string PhysicalOptions
        {
            get { return physicalOptions; }
            set { physicalOptions = value; }
        }

        IList<PdmColumn> columns;

        public IList<PdmColumn> Columns
        {
            get { return columns; }
        }

        IList<PdmKey> keys;

        public IList<PdmKey> Keys
        {
            get { return keys; }
        }

        public void AddColumn(PdmColumn mColumn)
        {
            if (columns == null)
            {
                columns = new List<PdmColumn>();
            }
            columns.Add(mColumn);
        }

        public void AddKey(PdmKey mKey)
        {
            if (keys == null)
            {
                keys = new List<PdmKey>();
            }
            keys.Add(mKey);
        }
    }
}
