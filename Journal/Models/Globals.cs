using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal.Models
{
    public static class Globals
    {
        static Globals()
        {

        }

        public static string ProjectTitle { get; } = "Journal";
        public static string AdminTitle { get; } = "Journal Admin Panel";
        public static string ProjectURL { get; } = "https://www.3031313.xyz";
        public static string AdminURL { get; } = "https://www.3031313.xyz/admin";

        public static string MediaUploadsPath { get; } = "/uploads/images/";
        public static string FilesUploadsPath { get; } = "/uplaods/docs/";

        public static IDictionary<string, int[]> MediaSizes { get; } = new Dictionary<string, int[]>()
        {
            { "thumbnails", new int[2] { 100, 100 } },
            { "1920x1080", new int[2] { 1920, 1080 } },
            { "500x720", new int[2] { 500, 720 } },
            { "600x320", new int[2] { 600, 320 } },
            { "300x300", new int[2] { 300, 300 } },
        };

        public static IDictionary<string, string> RecaptchaKeys { get; } = new Dictionary<string, string>()
        {
            { "publicKey", "6LcXNtMUAAAAAKzXaM9T4FiJGrOUT7xLXDkaHZ6K" },
            { "privateKey", "6LcXNtMUAAAAAO3pTr173zysUF0r0kTfgWHy-ow8" }
        };
    }
}