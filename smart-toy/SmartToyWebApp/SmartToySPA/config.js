var config = {
    TokenEndPoint: "http://localhost:1828/Token",
    WebApiEndPoint: "http://localhost:1828/",
    Methods: {
        Info: "toy/info",
        CountOfToys: "user/toys/count",
        Money: "user/money",
        Toys: "user/toys",
        AddNewToy: "user/toys",

        GetStoreGames: "store/games",
        GetStoreActions: "store/actions",
        GetStoreStories: "store/stories",
        GetStoreSongs: "store/songs",

        BuyAction: "store/action",
        BuyStory: "store/story",
        BuyGame: "store/game",
        BuySong: "store/song",

        DeleteToy: "toy",
        Register: "api/Account/Register",
        GetActions: "user/actions",
        GetStoriesAndSongs: "user/storiesAndSongs",
        GetGames: "user/games"
    }
};

window.GlobalVars = {};