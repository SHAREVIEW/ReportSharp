using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSharpCore;
using ReportSharpCore.Model;
using Newtonsoft;
using Newtonsoft.Json;
using ReportSharpCore.Interface;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using ReportSharpCore.Model;

namespace ReportSharp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<object> Items { get; set; }

        private string compiledHtml;
        public string CompiledHtml
        {
            get { return compiledHtml; }
            set
            {
                if (compiledHtml != value)
                {
                    compiledHtml = value;
                    RaisePropertyChanged("CompiledHtml");
                }
            }
        }

        private RelayCommand compile;
        public RelayCommand Compile
        {
            get { return compile; }
            set
            {
                if (compile != value)
                {
                    compile = value;
                    RaisePropertyChanged("Compile");
                }
            }
        }

        public MainViewModel()
        {
            Compile = new RelayCommand(async() => {
                var client = new ReportingClient();
                var group = new ReportGroup("Relatório de teste", Items);
                group.Options = new Dictionary<string, HtmlOptions>();
                group.Options.Add("Nome", new HtmlOptions { Color = "red" });
                CompiledHtml = await client.Render(new IReportGroup[] { group });
            });

            Items = new object[] {
                new {
                    Nome = "Teste1",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste2",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste3",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste4",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste5",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste6",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste7",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste8",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste9",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste10",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste11",
                    Idade = 22,
                    Profissao = "Programador"
                },
                new {
                    Nome = "Teste12",
                    Idade = 22,
                    Profissao = "Programador"
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
