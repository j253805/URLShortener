using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace URLShortener
{
    public class URLShortener
    {
        private string URL;
        private Dictionary<string, string> urlToShortMap;

        private string[] availableCharacters =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        public URLShortener()
        {
            urlToShortMap = new Dictionary<string, string>();
        }

        public URLShortener(string URL)
        {
            this.URL = URL;
            urlToShortMap = new Dictionary<string, string>();
        }

        public void mapUrl(string URL)
        {
            string shortLink = generateShortLink(URL);
            urlToShortMap.Add(URL, shortLink);
        }

        public string extractURLWithoutTLD(string URL)
        {
            string URLWithouthTLD = "";
            // Identifies URL TLD
            for (int character = URL.Length - 1; character >= 0; character--)
            {
                // End of TLD
                if (URL[character] == '.')
                {
                    URLWithouthTLD = URL.Substring(0, character);
                    break;
                }
            }

            return URLWithouthTLD;
        }

        private string generateShortLink(string URL)
        {
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            string URLWithouthTLD = extractURLWithoutTLD(URL);
            string shortLink = "joe.ly/";
            string URLOrigin = string.Join("", URLWithouthTLD.Take(1).Concat(URLWithouthTLD.TakeLast(2)));
            string shortLinkID = string.Join("", availableCharacters.OrderBy(x => random.Next()).Take(3));
            string fullShortLink = string.Join("", shortLink.Concat(URLOrigin.Concat(shortLinkID)));

            return fullShortLink;
        }

        public void printMappings()
        {
            foreach (KeyValuePair<string, string> pair in urlToShortMap)
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