using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartToyWebApp.Models.ViewModels
{
    public class InfoAboutToyViewModel
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }
        public Guid Uid { get; set; }
        public float Temperature { get; set; }
        public string SoftwareVersion { get; set; }
        public int Battery { get; set; }
        public int Type { get; set; }
    }
}
