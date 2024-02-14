using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace URLShortener
{
    public class URLShortener
    {
        private string _url;
        private Dictionary<string, string> _urlToShortMap;

        private string[] _availableCharacters =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        public URLShortener()
        {
            _urlToShortMap = new Dictionary<string, string>();
        }

        public URLShortener(string url)
        {
            this._url = url;
            _urlToShortMap = new Dictionary<string, string>();
        }

        public void MapUrl(string url)
        {
            string shortLink = GenerateShortLink(url);
            _urlToShortMap.Add(url, shortLink);
        }

        public string ExtractURLWithoutTLD(string url)
        {
            string URLWithouthTLD = "";
            // Identifies URL TLD
            for (int character = url.Length - 1; character >= 0; character--)
            {
                // End of TLD
                if (url[character] == '.')
                {
                    URLWithouthTLD = url.Substring(0, character);
                    break;
                }
            }

            return URLWithouthTLD;
        }

        private string GenerateShortLink(string URL)
        {
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            string URLWithouthTLD = ExtractURLWithoutTLD(URL);
            string shortLink = "joe.ly/";
            string URLOrigin = string.Join("", URLWithouthTLD.Take(1).Concat(URLWithouthTLD.TakeLast(2)));
            string shortLinkID = string.Join("", _availableCharacters.OrderBy(x => random.Next()).Take(3));
            string fullShortLink = string.Join("", shortLink.Concat(URLOrigin.Concat(shortLinkID)));

            return fullShortLink;
        }

        public void PrintMappings()
        {
            foreach (KeyValuePair<string, string> pair in _urlToShortMap)
            {
                string key = pair.Key;
                string value = pair.Value;

                // Use key and value here
                Console.WriteLine($"Key: {key}");
                Console.WriteLine($"Value: {value}");
            }

        }
    }
}