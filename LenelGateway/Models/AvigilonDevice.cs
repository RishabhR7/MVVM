using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenelGateway.Models
{
    public class AvigilonDevice : INotifyPropertyChanged
    {
        private string _IP;
        public string IP
        {
            get { return _IP; }
            set
            {
                _IP = value;
                RaisePropertyChanged("IP");
            }
        }

        private string _version;
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                RaisePropertyChanged("Version");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
