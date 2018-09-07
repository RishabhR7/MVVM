using LenelGateway.Helper;
using LenelGateway.Models;
using LenelGateway.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenelGateway.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<AvigilonDevice> deviceList { get; set; }
        public MainWindowViewModel()
        {
            deviceList = new ObservableCollection<AvigilonDevice>
            {
                new AvigilonDevice { IP = "172.18.100.10", Version = "1.0", Status = " New " },
                new AvigilonDevice { IP = "172.18.100.30", Version = "3.0", Status = "Ready" },
                new AvigilonDevice { IP = "172.18.100.50", Version = "5.0", Status = " New " },
                new AvigilonDevice { IP = "172.18.100.70", Version = "7.0", Status = "Ready" }
            };

            AddNewDeviceCommand = new RelayCommand(AddNewDeviceToExistingList);
            RemoveSelectedDeviceCommand = new RelayCommand(RemoveSelectedDevice);
            OpenAlarmWindowCommand = new RelayCommand(OpenAlarmWindow);
        }

        public RelayCommand AddNewDeviceCommand { get; set; }
        public RelayCommand RemoveSelectedDeviceCommand { get; set; }
        public RelayCommand OpenAlarmWindowCommand { get; set; }


        object _SelectedAvigilonDevice;
        public object SelectedAvigilonDevice
        {
            get
            {
                return _SelectedAvigilonDevice;
            }
            set
            {
                if (_SelectedAvigilonDevice != value)
                {
                    _SelectedAvigilonDevice = value;
                    RaisePropertyChanged("SelectedAvigilonDevice");
                }
            }
        }

        public void AddNewDeviceToExistingList(object newDevice)
        {
            ConnectToAvigilonSiteViewModel connectObj = new ConnectToAvigilonSiteViewModel();
            ConnectToAvigilonSite connectToAvigilonSite = new ConnectToAvigilonSite
            {
                DataContext = connectObj
            };
            connectObj.OnRequestClose += (s, e) => connectToAvigilonSite.Close();
            connectToAvigilonSite.ShowDialog();

            AvigilonDevice newAvigilonDevice = connectObj.GetNewAvigilonDevice();

            try
            {
                if (newAvigilonDevice.IP == null || newAvigilonDevice.Status == null || newAvigilonDevice.Version == null)
                    return;
                deviceList.Add(new AvigilonDevice { IP = newAvigilonDevice.IP.ToString(), Status = newAvigilonDevice.Status.ToString(), Version = newAvigilonDevice.Version.ToString() });
            }
            catch (Exception ex)
            {
            }
        }

        public void RemoveSelectedDevice(object newDevice)
        {
            try
            {
                deviceList.Remove(_SelectedAvigilonDevice as AvigilonDevice);
            }
            catch (Exception ex)
            {
            }
        }

        public void OpenAlarmWindow(object obj)
        {
            ConfigurationTool ctWindow = new ConfigurationTool();
            ctWindow.ShowDialog();
        }
    }
}
