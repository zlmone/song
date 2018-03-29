using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Data;
using System.Collections;
using System.Windows.Documents;
using System.Windows.Input;

namespace WSH.WPF.Common
{
    public class BindConfig {
        public string DisplayPath { get; set; }
        public string ValuePath { get; set; }
        public IEnumerable ItemSource{get;set;}
        public object SelectedValue{get;set;}
        public int? SelectedIndex{get;set;}
    }
    public class DataBind
    {
        public static void SetRichText(RichTextBox rich, string text)
        {
            FlowDocument doc = new FlowDocument(new Paragraph(new Run(text)));
            rich.Document = doc;
        }
        public static void BindCombox(ComboBox combox, BindConfig config)
        {
            combox.ItemsSource = config.ItemSource;
            combox.DisplayMemberPath = config.DisplayPath;
            if (string.IsNullOrEmpty(config.ValuePath))
            {
                config.ValuePath = config.DisplayPath;
            }
            combox.SelectedValuePath = config.ValuePath;
            if (config.SelectedValue != null)
            {
                combox.SelectedValue = config.SelectedValue;
            }
            else if (config.SelectedIndex.HasValue)
            {
                combox.SelectedIndex = config.SelectedIndex.Value;
            }
        }
       
    }
}
