using System;
using System.Collections.Generic;

namespace SmartToyWebApp.Models.ViewModels
{
    public class StoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Cost { get; set; }
    }
}
