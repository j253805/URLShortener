using System;
namespace URLShortener;
public class Program
{

    public static void Main(string[] args)
    {

        URLShortener shrtener = new URLShortener();
        shrtener.mapUrl("youtube.com");
        shrtener.mapUrl("google.com");
        shrtener.printMappings();
    }
}

