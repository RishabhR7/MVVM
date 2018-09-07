using LenelGateway.Helper;
using LenelGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LenelGateway.ViewModel
{
    class ConnectToAvigilonSiteViewModel : BaseViewModel
    {
        private string ip;
        public string IP
        {
            get { return this.ip; }
            set
            {
                if (!string.Equals(this.ip, value))
                {
                    this.ip = value;
                }
            }
        }

        private string version;
        public string Version
        {
            get { return this.version; }
            set
            {
                if (!string.Equals(this.version, value))
                {
                    this.version = value;
                }
            }
        }

        private string status;
        public string Status
        {
            get { return this.status; }
            set
            {
                if (!string.Equals(this.status, value))
                {
                    this.status = value;
                }
            }
        }

        public RelayCommand NewAvigilonDeviceCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }

        public ConnectToAvigilonSiteViewModel()
        {
            NewAvigilonDeviceCommand = new RelayCommand(AddNewAvigilonDevice);
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }
        AvigilonDevice av;

        public event EventHandler OnRequestClose;
        public void AddNewAvigilonDevice(object newDevice)
        {
            av = new AvigilonDevice();
            av.IP = this.ip;
            av.Version = this.version;
            av.Status=this.status;
            OnRequestClose(this, new EventArgs());
        }

        public void CloseWindow(object newDevice)
        {
            OnRequestClose(this, new EventArgs());
        }

        public AvigilonDevice GetNewAvigilonDevice()
        {
            return av;
        }
       
    }
}
