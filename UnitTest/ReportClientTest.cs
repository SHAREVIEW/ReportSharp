using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ReportSharpCore;
using ReportSharpCore.Model;
using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSharpCore.Model;

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
                    Profissão = "Programador",
                    Coluna1 = "valorColuna1",
                    Coluna2 = "valorColuna2",
                    Coluna3 = "valorColuna3",
                    Coluna4 = "valorColuna4",
                    Coluna5 = "valorColuna5",
                    Coluna6 = "valorColuna6",
                    Coluna7 = "valorColuna7",
                    Coluna8 = "valorColuna8",
                    Coluna9 = "valorColuna9",
                    Coluna10 = "valorColuna10",
                    Coluna11 = "valorColuna11",
                    Coluna12 = "valorColuna12",
                    Coluna13 = "valorColuna13",
                    Coluna14 = "valorColuna14",
                    Coluna15 = "valorColuna15",
                    Coluna16 = "valorColuna16",
                    Coluna17 = "valorColuna17",
                    Coluna18 = "valorColuna18",
                    Coluna19 = "valorColuna19"
                },
                new {
                    Nome = "Teste2",
                    Idade = 18,
                    Profissão = "Programador",
                    Coluna1 = "valorColuna1",
                    Coluna2 = "valorColuna2",
                    Coluna3 = "valorColuna3",
                    Coluna4 = "valorColuna4",
                    Coluna5 = "valorColuna5",
                    Coluna6 = "valorColuna6",
                    Coluna7 = "valorColuna7",
                    Coluna8 = "valorColuna8",
                    Coluna9 = "valorColuna9",
                    Coluna10 = "valorColuna10",
                    Coluna11 = "valorColuna11",
                    Coluna12 = "valorColuna12",
                    Coluna13 = "valorColuna13",
                    Coluna14 = "valorColuna14",
                    Coluna15 = "valorColuna15",
                    Coluna16 = "valorColuna16",
                    Coluna17 = "valorColuna17",
                    Coluna18 = "valorColuna18",
                    Coluna19 = "valorColuna19"
                },
                new {
                    Nome = "Teste3",
                    Idade = 18,
                    Profissão = "Programador",
                    Coluna1 = "valorColuna1",
                    Coluna2 = "valorColuna2",
                    Coluna3 = "valorColuna3",
                    Coluna4 = "valorColuna4",
                    Coluna5 = "valorColuna5",
                    Coluna6 = "valorColuna6",
                    Coluna7 = "valorColuna7",
                    Coluna8 = "valorColuna8",
                    Coluna9 = "valorColuna9",
                    Coluna10 = "valorColuna10",
                    Coluna11 = "valorColuna11",
                    Coluna12 = "valorColuna12",
                    Coluna13 = "valorColuna13",
                    Coluna14 = "valorColuna14",
                    Coluna15 = "valorColuna15",
                    Coluna16 = "valorColuna16",
                    Coluna17 = "valorColuna17",
                    Coluna18 = "valorColuna18",
                    Coluna19 = "valorColuna19"
                },
                new {
                    Nome = "Teste4",
                    Idade = 18,
                    Profissão = "Programador",
                    Coluna1 = "valorColuna1",
                    Coluna2 = "valorColuna2",
                    Coluna3 = "valorColuna3",
                    Coluna4 = "valorColuna4",
                    Coluna5 = "valorColuna5",
                    Coluna6 = "valorColuna6",
                    Coluna7 = "valorColuna7",
                    Coluna8 = "valorColuna8",
                    Coluna9 = "valorColuna9",
                    Coluna10 = "valorColuna10",
                    Coluna11 = "valorColuna11",
                    Coluna12 = "valorColuna12",
                    Coluna13 = "valorColuna13",
                    Coluna14 = "valorColuna14",
                    Coluna15 = "valorColuna15",
                    Coluna16 = "valorColuna16",
                    Coluna17 = "valorColuna17",
                    Coluna18 = "valorColuna18",
                    Coluna19 = "valorColuna19"
                },
                new {
                    Nome = "Teste5",
                    Idade = 18,
                    Profissão = "Programador",
                    Coluna1 = "valorColuna1",
                    Coluna2 = "valorColuna2",
                    Coluna3 = "valorColuna3",
                    Coluna4 = "valorColuna4",
                    Coluna5 = "valorColuna5",
                    Coluna6 = "valorColuna6",
                    Coluna7 = "valorColuna7",
                    Coluna8 = "valorColuna8",
                    Coluna9 = "valorColuna9",
                    Coluna10 = "valorColuna10",
                    Coluna11 = "valorColuna11",
                    Coluna12 = "valorColuna12",
                    Coluna13 = "valorColuna13",
                    Coluna14 = "valorColuna14",
                    Coluna15 = "valorColuna15",
                    Coluna16 = "valorColuna16",
                    Coluna17 = "valorColuna17",
                    Coluna18 = "valorColuna18",
                    Coluna19 = "valorColuna19"
                },
                new {
                    Nome = "Teste6",
                    Idade = 18,
                    Profissão = "Programador",
                    Coluna1 = "valorColuna1",
                    Coluna2 = "valorColuna2",
                    Coluna3 = "valorColuna3",
                    Coluna4 = "valorColuna4",
                    Coluna5 = "valorColuna5",
                    Coluna6 = "valorColuna6",
                    Coluna7 = "valorColuna7",
                    Coluna8 = "valorColuna8",
                    Coluna9 = "valorColuna9",
                    Coluna10 = "valorColuna10",
                    Coluna11 = "valorColuna11",
                    Coluna12 = "valorColuna12",
                    Coluna13 = "valorColuna13",
                    Coluna14 = "valorColuna14",
                    Coluna15 = "valorColuna15",
                    Coluna16 = "valorColuna16",
                    Coluna17 = "valorColuna17",
                    Coluna18 = "valorColuna18",
                    Coluna19 = "valorColuna19"
                },
            };

            var group = new ReportGroup("Lista de programadores", list );
            var client = new ReportingClient();
            var strReport = await client.CompileReport(new IReportGroup[] { group });
            Assert.IsTrue(true);
        }
    }
}
