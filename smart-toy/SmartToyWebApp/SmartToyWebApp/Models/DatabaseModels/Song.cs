using System;
using System.Collections.Generic;

namespace SmartToyWebApp.Models.DatabaseModels
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string SongAudioFileUrl { get; set; }

        public int Cost { get; set; }

        public List<ApplicationUser> Users { get; set; } 
    }
}
