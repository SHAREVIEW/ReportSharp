using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Model
{
    public static class PageOptions
    {
        public static PageSize A3 { get; private set; }
        public static PageSize A4 { get; private set; }
        public static PageSize Letter { get; private set; }

        static PageOptions()
        {
            A3 = new PageSize("A3", 297, 420);
            A4 = new PageSize("A4", 210, 297);
            Letter = new PageSize("Letter", 216, 279);
        }

        public enum PageOrientation {
            Portrait,
            Landscape
        }

        public class PageSize {
            public string Name { get; private set; }
            public double Width { get; private set; }
            public double Height { get; private set; }

            public override string ToString()
            {
                return Name;
            }

            public PageSize(string _name, double _width, double _height )
            {
                Name = _name;
                Width = _width;
                Height = _height;
            }
        }
    }
}
