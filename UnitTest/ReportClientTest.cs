using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ReportSharpCore;
using ReportSharpCore.Model;
using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ReportClientTest
    {
        [TestMethod]
        public async Task ReportClientTest_CompileReport() {
            var list = new object[] {
                new {
                    Nome = "Teste1",
                    Idade = 18,
                    Profissão = "Programador"
                },
                new {
                    Nome = "Teste2",
                    Idade = 18,
                    Profissão = "Programador"
                },
                new {
                    Nome = "Teste3",
                    Idade = 18,
                    Profissão = "Programador"
                },
                new {
                    Nome = "Teste4",
                    Idade = 18,
                    Profissão = "Programador"
                },
                new {
                    Nome = "Teste5",
                    Idade = 18,
                    Profissão = "Programador"
                },
                new {
                    Nome = "Teste6",
                    Idade = 18,
                    Profissão = "Programador"
                },
            };

            var group = new ReportGroup("Lista de programadores") { Items = list };
            var client = new ReportingClient();
            var strReport = await client.CompileReport(new IReportGroup[] { group });
            Assert.IsTrue(true);
        }
    }
}
