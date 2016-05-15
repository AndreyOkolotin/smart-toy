using System;

namespace SmartToyWebApp.Models.DatabaseModels
{
    public class Toy
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public string FriendlyName { get; set; }
        public Guid Uid { get; set; }
        public float Temperature { get; set; }
        public string SoftwareVersion { get; set; }
        public int Battery { get; set; }
        public int Type { get; set; }
    }
}
