using System;
namespace app {
    public static class Constants {

        public const string SpotifyClientId = "791961aaeda34500b77fda86eaaa69a7";
        public const string SpotifyClientSecret = "5103b160f8ca41cfb57b20e56c9e44a9";
        public const string RedirectUrl = "https://app/login";


        public const string DbFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DbPath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DbFilename);
            }
        }

    }
}

