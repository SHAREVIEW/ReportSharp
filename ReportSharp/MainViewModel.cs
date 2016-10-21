using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharp
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string strJson;
        public string StrJson
        {
            get { return strJson; }
            set
            {
                if (strJson != value)
                {
                    strJson = value;
                    RaisePropertyChanged("StrJson");
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



        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
