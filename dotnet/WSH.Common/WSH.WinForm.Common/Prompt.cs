using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WSH.Options.Common;

namespace WSH.WinForm.Common
{
    public class Prompt
    {
        public Prompt() { }
        public Prompt(string content) {
            this.content = content;
        }
        private string title = MsgBox.DefaultTitle;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string defaultValue;

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }
        private int width = 300;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height = 150;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private bool required = true;

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }
        /// <summary>
        /// 返回结果的方法委托
        /// </summary>
        /// <returns></returns>
        public  event CustomValidateHanlder OnCustomValidate;
        public string Show()
        {
            string result = null;
            int padding = 3;
            int buttonWidth = 80;
            int buttonHeight = 30;
            int contentHeight = 15 + padding * 2;
            Form f = new Form();
            f.Text = Title;
            f.ClientSize = new System.Drawing.Size(Width, Height);
            int top = padding;
            int textHeight = Height - (padding * 6);
            int controlWidth = Width - (padding * 2);
            int buttonLeft = (Width - (buttonWidth * 2 + 10)) / 2;
            int buttonTop = Height - buttonHeight - padding * 2;
            textHeight -= buttonHeight - padding;

            if (!string.IsNullOrEmpty(Content))
            {
                Label l = new Label();
                l.AutoSize = true;
                l.Location = new System.Drawing.Point(padding, padding * 2);
                l.Text = Content + "：";
                f.Controls.Add(l);
                top += contentHeight;
                textHeight -= contentHeight;
            }
            TextBox t = new TextBox();
            t.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left)));
            t.Text = DefaultValue;
            t.Multiline = true;
            t.WordWrap = true;
            t.Width = controlWidth-20;
            t.Height = textHeight;
            t.Location = new System.Drawing.Point(padding, top);
            f.Controls.Add(t);
            ErrorProvider error = new ErrorProvider();
            //生成按钮
            Button ok = new Button();
            ok.Click += (sender, e) =>
            {
                result = t.Text.Trim();
                ValidResult r = new ValidResult()
                {
                    Value = result
                };
                if(Required){
                    if (string.IsNullOrEmpty(result))
                    {
                        r.IsSuccess = false;
                        r.Msg = "必填";
                    }
                }
                if (OnCustomValidate != null && r.IsSuccess)
                {
                    r.Value = result;
                    OnCustomValidate(this,r);
                }
                if (r.IsSuccess)
                {
                    f.Close();
                }
                else {
                    if(string.IsNullOrEmpty(r.Msg)){
                        r.Msg = "输入不正确";
                    }
                    error.SetError(t, r.Msg);
                }
            };
            ok.Anchor = ((AnchorStyles)((AnchorStyles.Bottom)));
            ok.Text = "确定";
            ok.Location = new System.Drawing.Point(buttonLeft, buttonTop);
            ok.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            f.Controls.Add(ok);
            Button cancel = new Button();
            cancel.Click += (sender, e) =>
            {
                result = string.Empty;
                f.Close();
            };
            cancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom)));
            cancel.Text = "取消";
            buttonLeft = buttonLeft + buttonWidth + 10;
            cancel.Location = new System.Drawing.Point(buttonLeft, buttonTop);
            cancel.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            f.Controls.Add(cancel);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            return result;
        }
    }
}
