using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartToyWebApp.Models.ViewModels
{
    public class InfoAboutToyViewModel
    {
        public string SoftwareVersion { get; set; }
        public int Battery { get; set; }
        public int Temperature { get; set; }
    }
}
