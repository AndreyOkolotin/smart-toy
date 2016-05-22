using System.Collections.Generic;
using System.Linq;
using SmartToyWebApp.Models.DatabaseModels;
using SmartToyWebApp.Models.ViewModels;

namespace SmartToyWebApp.Models
{
    public static class Extensions
    {
        public static List<ActionViewModel> ToViewModel(this List<Action> actions)
        {
            if (actions == null)
            {
                return null;
            }

            return actions.Select(a => new ActionViewModel
            {
                Cost = a.Cost,
                Description = a.Description,
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Name = a.Name,
                Type = a.Type
            }).ToList();
        }

        public static List<GameViewModel> ToViewModel(this List<Game> games)
        {
            if (games == null)
            {
                return null;
            }

            return games.Select(a => new GameViewModel()
            {
                Cost = a.Cost,
                Description = a.Description,
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Name = a.Name
            }).ToList();
        }

        public static List<StoryViewModel> ToViewModel(this List<Story> stories)
        {
            if (stories == null)
            {
                return null;
            }

            return stories.Select(a => new StoryViewModel()
            {
                Cost = a.Cost,
                Description = a.Description,
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Name = a.Name
            }).ToList();
        }

        public static List<SongViewModel> ToViewModel(this List<Song> songs)
        {
            if (songs == null)
            {
                return null;
            }

            return songs.Select(a => new SongViewModel()
            {
                Cost = a.Cost,
                Description = a.Description,
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Name = a.Name
            }).ToList();
        }

        public static List<StoryOrSongViewModel> ToStoryOrSongViewModel(this List<Song> songs)
        {
            if (songs == null)
            {
                return null;
            }

            return songs.Select(a => new StoryOrSongViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                StoryOrSong = 0
            }).ToList();
        }
        public static List<StoryOrSongViewModel> ToStoryOrSongViewModel(this List<Story> stories)
        {
            if (stories == null)
            {
                return null;
            }

            return stories.Select(a => new StoryOrSongViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                StoryOrSong = 1
            }).ToList();
        } 
    }
}
