using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.CodeDom.Compiler;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.Common
{
    [Serializable]
    public class CodeBuilderHost : ITextTemplatingEngineHost
    {
        /// <summary>
        /// 所属项目
        /// </summary>
        public ProjectEntity Project { get; set; }
        /// <summary>
        /// 所属表或集合
        /// </summary>
        public TableEntity Table { get; set; }
        /// <summary>
        /// 列信息集合
        /// </summary>
        public List<ColumnEntity> Columns { get; set; }
        /// <summary>
        /// 模版文件地址
        /// </summary>
        public string TemplateFile { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfoEntity User { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public object Params { get; set; }
        private string fileExtension = ".cs";
        /// <summary>
        /// 代码文件的扩展名(默认.cs)
        /// </summary>
        public string FileExtension
        {
            get { return fileExtension; }
            set { fileExtension = value; }
        }
        private Encoding fileEncoding = Encoding.Default;
        /// <summary>
        /// 代码文件编码
        /// </summary>
        public Encoding FileEncoding
        {
            get { return fileEncoding; }
            set { fileEncoding = value; }
        }
        public CompilerErrorCollection Errors { get; set; }

        public object GetHostOption(string optionName)
        {
            object returnObject;
            switch (optionName)
            {
                case "CacheAssemblies":
                    returnObject = true;
                    break;
                default:
                    returnObject = null;
                    break;
            }
            return returnObject;
        }

        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
            content = System.String.Empty;
            location = System.String.Empty;
            if (File.Exists(requestFileName))
            {
                content = File.ReadAllText(requestFileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogErrors(System.CodeDom.Compiler.CompilerErrorCollection errors)
        {
            Errors = errors;
        }

        public AppDomain ProvideTemplatingAppDomain(string content)
        {
            return AppDomain.CreateDomain("Generation App Domain");
        }

        public string ResolveAssemblyReference(string assemblyReference)
        {
            if (File.Exists(assemblyReference))
            {
                return assemblyReference;
            }
            string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), assemblyReference);
            if (File.Exists(candidate))
            {
                return candidate;
            }
            return assemblyReference;
        }

        public Type ResolveDirectiveProcessor(string processorName)
        {
            throw new NotImplementedException();
        }

        public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
        {
            return string.Empty;
        }

        public string ResolvePath(string path)
        {
            string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), path);
            if (File.Exists(candidate))
            {
                return candidate;
            }
            return path;
        }

        public void SetFileExtension(string extension)
        {
            fileExtension = extension;
        }

        public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
        {
            fileEncoding = encoding;
        }

        public IList<string> StandardAssemblyReferences
        {
            get
            {
                return new string[]
                {
                    typeof(System.Uri).Assembly.Location,
                    typeof(System.Collections.Generic.List<>).Assembly.Location,
                    typeof(WSH.CodeBuilder.DispatchServers.Entity).Assembly.Location,
                    typeof(CodeBuilderHost).Assembly.Location,
                    typeof(WSH.Common.Helper.StringHelper).Assembly.Location,
                    typeof(WSH.CodeBuilder.Common.CodeHelper).Assembly.Location,
                    typeof(WSH.CodeBuilder.Common.DataTypeManager).Assembly.Location,
                    typeof(System.Text.StringBuilder).Assembly.Location
                };
            }
        }

        public IList<string> StandardImports
        {
            get
            {
                return new string[]{
                    "System",
                    "WSH.CodeBuilder.Common",
                    "System.Collections.Generic",
                    "WSH.CodeBuilder.DispatchServers",
                    "WSH.Common.Helper",
                    "WSH.Common",
                    "System.Text"
                };
            }
        }

        string ITextTemplatingEngineHost.TemplateFile
        {
            get { return this.TemplateFile; }
        }
    }
}
