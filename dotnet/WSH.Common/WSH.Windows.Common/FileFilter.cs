using System;
using System.Collections.Generic;
 
using System.Text;

namespace WSH.Windows.Common
{
    public class FileFilter
    {
        public const string Pdm = "Pdm文件(*.pdm)|*.pdm";
        public const string Excel2003 = "Excel文件(*.xls)|*.xls";
        public const string Excel = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";

        public const string Word2003 = "Word文件(*.doc)|*.doc";
        public const string Word = "Word文件(*.doc;*.docx)|*.doc;*.docx";

        public const string PPT2003 = "PPT文件(*.ppt)|*.ppt";
        public const string PPT = "ppt和pptx文件|*.pptx;*.ppt";

        public const string Access2003 = "Access文件(*.mdb)|*.mdb";
        public const string Access = "Access文件(*.mdb;*.accdb)|*.mdb;*.accdb";

        public const string Txt = "文本文件(*.txt)|*.txt";

        public const string All = "所有文件(*.*)|*.*";

        public const string AddressBook = "通讯录文件(*.vcf;*.txt;*.xls;*.xlsx)|*.vcf;*.txt;*.xls;*.xlsx";
    }
}
