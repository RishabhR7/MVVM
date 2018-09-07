using LenelGateway.Helper;
using LenelGateway.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenelGateway.ViewModel
{
    class ConfigurationToolViewModel : BaseViewModel
    {
        public ObservableCollection<Alarm> alarmList { get; set; }
        public ObservableCollection<Alarm> alarmMappingList { get; set; }

        public ConfigurationToolViewModel()
        {
            alarmList = new ObservableCollection<Alarm>
            {
                new Alarm { ID= 1, Name = "Alarm 01", Site = "Optimus 60", PanelName = "ABC", Description="left"},
                new Alarm { ID= 2, Name = "Alarm 02", Site = "Optimus 74", PanelName = "ABC", Description="left"},
                new Alarm { ID= 3, Name = "Alarm 03", Site = "Optimus 60", PanelName = "ABC", Description="left"},
                new Alarm { ID= 4, Name = "Alarm 04", Site = "Optimus 74", PanelName = "ABC", Description="left"}
            };

            alarmMappingList = new ObservableCollection<Alarm>
            {
                new Alarm { ID= 5, Name = "Alarm 05", Site = "Optimus 60", PanelName = "XYZ", Description="right"},
                new Alarm { ID= 6, Name = "Alarm 06", Site = "Optimus 74", PanelName = "XYZ", Description="right"},
                new Alarm { ID= 7, Name = "Alarm 07", Site = "Optimus 60", PanelName = "XYZ", Description="right"},
                new Alarm { ID= 8, Name = "Alarm 08", Site = "Optimus 74", PanelName = "XYZ", Description="right"}
            };

            LeftToRight = new RelayCommand(MoveLeftToRight);
            RightToLeft = new RelayCommand(MoveRightToLeft);
        }


        object _SelectedAlarm;
        public object SelectedAlarm
        {
            get
            {
                return _SelectedAlarm;
            }
            set
            {
                if (_SelectedAlarm != value)
                {
                    _SelectedAlarm = value;
                    RaisePropertyChanged("SelectedAvigilonDevice");
                }
            }

        }
        public RelayCommand LeftToRight { get; set; }
        public RelayCommand RightToLeft { get; set; }

        public void MoveLeftToRight(object obj)
        {
            try
            {
                if (_SelectedAlarm!=null && !alarmMappingList.Contains(_SelectedAlarm as Alarm))
                {
                    alarmMappingList.Add(_SelectedAlarm as Alarm);
                    alarmList.Remove(_SelectedAlarm as Alarm);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void MoveRightToLeft(object obj)
        {
            try
            {
                if (_SelectedAlarm != null && !alarmList.Contains(_SelectedAlarm as Alarm))
                {
                    alarmList.Add(_SelectedAlarm as Alarm);
                    alarmMappingList.Remove(_SelectedAlarm as Alarm);
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
