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
        public string Width { get; set; }
        public string Height { get; set; }
        public DisplayValue? Display { get; set; }
        public int? ColsPan { get; set; }
        public int? RowsPan { get; set; }
        public string BootstrapClass { get; set; }

        public override string ToString()
        {
            StringBuilder opts = new StringBuilder();

            if (ColsPan != null)
                opts.AppendFormat(" colspan={0} ", ColsPan);
            if(RowsPan != null)
                opts.AppendFormat(" rowspan={0} ", RowsPan);
            if (BootstrapClass != null)
                opts.AppendFormat(" class='{0}' ", BootstrapClass);

            opts.Append("style='");
            if (Color != null)
                opts.AppendFormat("color:{0};", Color);
            if (BackgroundColor != null)
                opts.AppendFormat("background-color:{0};", BackgroundColor);
            if (FontFamily != null)
                opts.AppendFormat("font-family:{0};", FontFamily);
            if (FontSize != null)
                opts.AppendFormat("font-size:{0};", FontSize);
            if (Width != null)
                opts.AppendFormat("width:{0};", Width);
            if (Height != null)
                opts.AppendFormat("height:{0};", Height);
            if (Display != null)
                opts.AppendFormat("display:{0};", Display);
            opts.Append("'");

            return opts.ToString();
        }

        public enum DisplayValue {
            Inline,
            None
        }
    }
}
