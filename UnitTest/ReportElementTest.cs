using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ReportSharpCore.Model;
using ReportSharpCore.Enum;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class ReportElementTest
    {
        [TestMethod]
        public void ReportElement_ToString()
        {             
            var element = new ReportElement { Tag = HtmlTag.div, Content = "Teste", HtmlProperties = new ListHtmlProperties(new string[] { "class='test'", "style='color:black;'" }) };
            var strElement = element.ToString();
            Assert.IsTrue(strElement == "<div class='test' style='color:black;' > Teste </div>");
        }
        [TestMethod]
        public void ReportElement_Recursive_ToString()
        {
            var element1 = new ReportElement { Tag = HtmlTag.div, HtmlProperties = new ListHtmlProperties(new string[] { "class='test'", "style='color:black;'" }) };
            var element2 = new ReportElement { Tag = HtmlTag.div, Content = "Teste", HtmlProperties = new ListHtmlProperties(new string[] { "class='test'", "style='color:black;'" }) };
            element1.Content = element2;
            var strElement = element1.ToString();
            Assert.IsTrue(strElement == "<div class='test' style='color:black;' > <div class='test' style='color:red;' > Teste </div> </div>");
        }
    }
}
