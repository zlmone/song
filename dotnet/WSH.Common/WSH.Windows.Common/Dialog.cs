using System;
using System.Collections.Generic;
 
using System.Text;
using System.Windows.Forms;

namespace WSH.Windows.Common
{
    public enum DialogType
    {
        File, Folder,Save
    }
   public  class Dialog
   {
       #region 弹出文件对话框
       /// <summary>
       /// 弹出对话框，选择文件夹
       /// </summary>
       /// <param name="oldPath"></param>
       /// <returns></returns>
       public static string  GetFolder(string oldPath,string title=""){
            FolderBrowserDialog folder=new FolderBrowserDialog ();
            folder.Description = title;
           if(!string.IsNullOrEmpty(oldPath)){
                folder.SelectedPath=oldPath;
           }
           DialogResult result= folder.ShowDialog();
          if(result== DialogResult.OK){
                string path= folder.SelectedPath;
                return path;
           }
           return null;
       }
       public static string GetFolder() {
           return GetFolder(null,"请选择文件夹");
       }
       public static string GetSaveFile(string fileName, string filter = null)
       {
           SaveFileDialog dialog = new SaveFileDialog();
           dialog.FileName = fileName;
           if (!string.IsNullOrEmpty(filter))
           {
               dialog.Filter = filter;
           }
           DialogResult result = dialog.ShowDialog();
           if(result== DialogResult.OK){
               string path = dialog.FileName;
               return path;
           }
           return null;
       }
       public static string[]  GetFileNames(string path=null,string filter=null) {
           OpenFileDialog dialog = new OpenFileDialog();
           if (!string.IsNullOrEmpty(path))
           {
               dialog.FileName = path;
           }
           if(!string.IsNullOrEmpty(filter)){
               dialog.Filter = filter;
           }
           dialog.Multiselect = true;
           DialogResult result = dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               return dialog.FileNames;
           }
           return null;
       }
       public static string GetFileName(string path = null, string filter = null) {
           OpenFileDialog dialog = new OpenFileDialog();
           if (!string.IsNullOrEmpty(path))
           {
               dialog.FileName = path;
           }
           if (!string.IsNullOrEmpty(filter))
           {
               dialog.Filter = filter;
           }
           DialogResult result = dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               string name = dialog.FileName;
               return name;
           }
           return null;
       }
       #endregion

       
   }
}
