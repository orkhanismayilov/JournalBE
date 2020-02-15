using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JournalProject.Models
{
    public static class Globals
    {
        static Globals() { }

        public static string Lang { get; set; } = "az";
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

        public static string NoReplyEmail { get; } = "no-reply@3031313.xyz";
        public static System.Net.NetworkCredential NoReplyCredentials { get; } = new System.Net.NetworkCredential
        {
            UserName = "no-reply@3031313.xyz",
            Password = "@Z@syeD8JMj@34@"
        };
        public static System.Net.Mail.SmtpClient SMTP { get; } = new System.Net.Mail.SmtpClient
        {
            Host = "smtp.yandex.ru",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = NoReplyCredentials
        };

        public static async Task<bool> VerifyRecaptcha(string token)
        {
            IDictionary<string, string> postData = new Dictionary<string, string>
            {
                { "secret", RecaptchaKeys["privateKey"] },
                { "response", token }
            };

            HttpClient httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(postData);
            var response = await httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);

            string result;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();

                JObject json = JObject.Parse(result);

                if (json.Value<bool>("success"))
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}