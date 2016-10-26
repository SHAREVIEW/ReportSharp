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
using ReportSharpCore.Enum;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.System;

namespace ReportSharp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<object> ItemsBody { get; set; }
        public IEnumerable<ReportSection.KeyValueColumn> ItemsHeader { get; set; }
        public IEnumerable<PageOptions.PageOrientation> Orientations { get; set; }
        public IEnumerable<PageOptions.PageSize> PageSizes { get; set; }


        private PageOptions.PageSize selectedPageSize;
        public PageOptions.PageSize SelectedPageSize
        {
            get { return selectedPageSize; }
            set
            {
                if (selectedPageSize != value)
                {
                    selectedPageSize = value;
                    RaisePropertyChanged("SelectedPageSize");
                }
            }
        }

        private PageOptions.PageOrientation selectedOrientation;
        public PageOptions.PageOrientation SelectedOrientation
        {
            get { return selectedOrientation; }
            set
            {
                if (selectedOrientation != value)
                {
                    selectedOrientation = value;
                    RaisePropertyChanged("SelectedOrientation");
                }
            }
        }

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

        private RelayCommand compileToFile;
        public RelayCommand CompileToFile
        {
            get { return compileToFile; }
            set
            {
                if (compileToFile != value)
                {
                    compileToFile = value;
                    RaisePropertyChanged("CompileToFile");
                }
            }
        }

        private RelayCommand copyToClipboard;
        public RelayCommand CopyToClipboard
        {
            get { return copyToClipboard; }
            set
            {
                if (copyToClipboard != value)
                {
                    copyToClipboard = value;
                    RaisePropertyChanged("CopyToClipboard");
                }
            }
        }


        public MainViewModel()
        {
            Orientations = new PageOptions.PageOrientation[] { PageOptions.PageOrientation.Landscape, PageOptions.PageOrientation.Portrait };

            PageSizes = new PageOptions.PageSize[] { PageOptions.A4, PageOptions.A3, PageOptions.Letter };

            Compile = new RelayCommand(async() => {
                var client = new ReportingClient();
                var group1 = GetItemsGroup();
                var group2 = GetHeaderGroup();
                CompiledHtml = await client.RenderToStringAsync(new IReportGroup[] { group2, group1 }, SelectedPageSize, SelectedOrientation);
            });

            CompileToFile = new RelayCommand(async() => {
                var client = new ReportingClient();
                var group1 = GetItemsGroup();
                var group2 = GetHeaderGroup();
                var file = await client.RenderToFileAsync(ApplicationData.Current.LocalFolder, "report.html", new IReportGroup[] { group2, group1 }, SelectedPageSize, SelectedOrientation);
                var teste = await Launcher.LaunchFileAsync(file);
            });

            CopyToClipboard = new RelayCommand(() => {
                var data = new DataPackage();
                data.SetText(CompiledHtml);
                Clipboard.SetContent(data);
            });

            #region Definição de items estáticos

            ItemsBody = new List<object>();

            for (var x = 0; x<1000; x++)
            {
                ((List<object>)ItemsBody).Add(new
                {
                    Nome = "Teste" + x,
                    Sobrenome = "Sobre" + x,
                    Idade = 22,
                    Profissao = "Programador"
                });
            }
            ItemsHeader = new ReportSection.KeyValueColumn[]
            {
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "Fantasy name:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "44568" }, 0),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "E-mail registered:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "wesleycalcados@hotmail.com " }, 1),
                new ReportSection.KeyValueColumn(null, null, 2),                   
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "company name:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "ANTONIO RUBENS OLIVEIRA VIANA ME" }, 0),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "email informed:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "wesleycalcados@hotmail.com " }, 1),
                new ReportSection.KeyValueColumn(null, null, 2),                   
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "Cust. Contact:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "" }, 0),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "Type Contact:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "" }, 1),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "Address:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "AVENIDA SAO PAULO,901 901" }, 2),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "Neighborhood:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "CID SAO JORGE" }, 0),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "phone:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "11 4458-6019" }, 1),
                new ReportSection.KeyValueColumn(new ReportElement { Tag = HtmlTag.span, Content = "Fantasy name:" }, new ReportElement { Tag = HtmlTag.span, HtmlProperties = new HtmlOptions { FontWeight = HtmlOptions.FontWeightValue.bold }, Content = "44568" }, 2)
            };

            #endregion
        }

        private IReportGroup GetItemsGroup()
        {
            var group = new ReportGroup("Relatório de teste", ItemsBody);
            group.Options = new Dictionary<string, HtmlOptions>();
            group.Options.Add("Nome_body", new HtmlOptions { Color = "red" });
            group.Options.Add("Sobrenome_head", new HtmlOptions { Display = HtmlOptions.DisplayValue.None });
            group.Options.Add("Nome_head", new HtmlOptions { ColsPan = 2 });
            return group;
        }

        private IReportGroup GetHeaderGroup()
        {
            var group = new ReportSection("Note: ", ItemsHeader);
            group.GroupHeader = new ReportElement { Tag = HtmlTag.h4, Content = group.Key };
            return group;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
