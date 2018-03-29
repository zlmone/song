using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.CodeDom.Compiler;
using WSH.Common.Helper;
using WSH.Options.Common;
using WSH.CodeBuilder.DispatchServers;
using System.Linq;

namespace WSH.CodeBuilder.Common
{
    public class CodeBuilderManager
    {
        public ProjectEntity Project;
        public UserInfoEntity User;
        public event ProgressHandler OnProgress;
        public StringBuilder Error = new StringBuilder();
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        public List<string> ExportByTables(
            List<string> Tables,
            List<TemplateEntity> Templates,
            string exportPath
        ) {
            int j = 0;
            int max = Tables.Count * Templates.Count;
            //导出的文件集合
            List<string> files = new List<string>();
            for (int i = 0; i < Tables.Count; i++)
            {
                foreach (TemplateEntity dic in Templates)
                {
                    j++;
                    files.Add(ExportByTable(Tables[i], dic, exportPath));
                    if (OnProgress != null) {
                        OnProgress(this, new ProgressEventArgs() { Max=max,Value=j });
                    }
                }
            }
            return files;
        }
        /// <summary>
        /// 根据模版获取生成的代码
        /// </summary>
        public string GetByTable(
            string tableName, 
            TemplateEntity templ
        ) {
            TableEntity table = service.GetTableByName(Project.ID.ToString(),tableName);
            CodeBuilderHost host = new CodeBuilderHost();
            host.User = User;
            host.Columns = service.GetColumnList(table.ID.ToString()).ToList();
            host.Project = Project;
            host.Table = table;
            host.FileExtension = templ.FileExtensions;
            host.TemplateFile = "";
            //开始生成代码
            Engine engine = new Engine();
            //string input = File.ReadAllText(host.TemplateFile,Encoding.Default);
            string input = templ.Content;
            string outputText = engine.ProcessTemplate(input, host);
            //写入生成错误信息
            foreach (CompilerError createError in host.Errors)
            {
                Error.AppendLine(createError.ToString());
            }
            return outputText;
        }
        /// <summary>
        /// 根据模板导出生成的代码
        /// </summary>
        public string ExportByTable(
            string tableName,
            TemplateEntity templ,
            string exportPath
        ) {
            string code = GetByTable(tableName, templ);
            //将生成代码写入文件
            string filePath = exportPath + @"\" +templ.FilePrefix+ ParseTableName(tableName)+ templ.FileName + templ.FileExtensions;
            FileHelper.WriteFile(filePath, code);
            return filePath;
        }
        public string ParseTableName(string name) {
            name = StringHelper.Capitalize(name).Replace("_","");
            return name;
        }
    }
}
