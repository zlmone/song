using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Tools.Common
{
    public class FieldLines
    {
        public static FieldLine GetFieldLine(string line)
        {
            string[] field = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
            FieldLine f = new FieldLine();
            f.Field = field[1];
            f.DataType = field[0];
            return f;
        }
    }
    public class FieldLine
    {
        private string dataType;
        /// <summary>
        /// DataType
        /// </summary>
        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        private string field;

        public string Field
        {
            get { return field; }
            set { field = value; }
        }
    }
}