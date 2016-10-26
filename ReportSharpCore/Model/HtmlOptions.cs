using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Model
{
    public class HtmlOptions
    {
        public string Color { get; set; }
        public string BackgroundColor { get; set; }
        public string FontFamily { get; set; }
        public string FontSize { get; set; }
        public FontWeightValue? FontWeight { get; set; }
        public FloatValue? Float { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public DisplayValue? Display { get; set; }
        public int? ColsPan { get; set; }
        public int? RowsPan { get; set; }
        public string CssClass { get; set; }
        public string TableLayout { get; set; }
        public string WordWrap { get; set; }
        public string Margin { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder opts = new StringBuilder();

            if (ColsPan != null)
                opts.AppendFormat(" colspan={0} ", ColsPan);
            if(RowsPan != null)
                opts.AppendFormat(" rowspan={0} ", RowsPan);
            if (CssClass != null)
                opts.AppendFormat(" class='{0}' ", CssClass);

            opts.Append("style='");
            if (Color != null)
                opts.AppendFormat("color:{0};", Color);
            if (BackgroundColor != null)
                opts.AppendFormat("background-color:{0};", BackgroundColor);
            if (FontFamily != null)
                opts.AppendFormat("font-family:{0};", FontFamily);
            if (FontSize != null)
                opts.AppendFormat("font-size:{0};", FontSize);
            if (FontWeight != null)
                opts.AppendFormat("font-weight:{0};", FontWeight);
            if (Width != null)
                opts.AppendFormat("width:{0};", Width);
            if (Height != null)
                opts.AppendFormat("height:{0};", Height);
            if (Display != null)
                opts.AppendFormat("display:{0};", Display);
            if(Float != null)
                opts.AppendFormat("float:{0};", Float);
            if (TableLayout != null)
                opts.AppendFormat("table-layout:{0};", TableLayout);
            if (WordWrap != null)
                opts.AppendFormat("word-wrap:{0};", WordWrap);
            if (Margin != null)
                opts.AppendFormat("margin:{0};", Margin);
            opts.Append("'");

            return opts.ToString();
        }

        public enum DisplayValue {
            Inline,
            None
        }

        public enum FloatValue
        {
            Right,
            Left
        }

        public enum FontWeightValue
        {
            bold, 
            bolder,
            lighter,
            normal
        }

        public static class TableLayoutValue {
            public const string Auto = "auto";
            public const string Fixed = "fixed";
        }

        public static class WordWrapValue {
            public const string normal = "normal";
            public const string BreakWord = "break-word";
        }
    }
}
