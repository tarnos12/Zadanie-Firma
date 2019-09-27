using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZadanieFirma.Firma.Contracts;

namespace ZadanieFirma.Firma
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
        }

        // #region-start
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

        // #region-end

        string _FirstName = string.Empty;
        public string FirstName
        {
            set
            {
                _FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        string _LastName = string.Empty;
        public string LastName
        {
            set
            {
                _LastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        /*string _input = string.Empty;
        public string Input
        {
            set
            {
                _input = value;
                Output = _input;
                RaisePropertyChanged("Input");
            }
        }

        string _output = string.Empty;
        public string Output
        {
            set
            {
                _output = value;
                RaisePropertyChanged("Output");
            }
            get
            {
                return _output;
            }
        }*/

        // Notyfikuje interfejs o zmianach w ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName_)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName_));
            }
        }
    }
}
