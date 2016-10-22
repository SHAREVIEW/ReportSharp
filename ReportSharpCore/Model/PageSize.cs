using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Model
{
    public static class PageSizes
    {
        public static PageSize A3 { get { return new PageSize("A3", 297, 420); } }
        public static PageSize A4 { get { return new PageSize("A4", 210, 297); } }
        public static PageSize Letter { get { return new PageSize("Letter", 210, 297); } }

        public class PageSize {
            public string Name { get; private set; }
            public double Width { get; private set; }
            public double Height { get; private set; }

            public PageSize(string _name, double _width, double _height )
            {
                Name = _name;
                Width = _width;
                Height = _height;
            }
        }
    }
}
