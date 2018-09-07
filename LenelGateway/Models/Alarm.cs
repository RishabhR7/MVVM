using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenelGateway.Models
{
    class Alarm
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _site;
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }

        private string _panelName;
        public string PanelName
        {
            get { return _panelName; }
            set { _panelName = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
