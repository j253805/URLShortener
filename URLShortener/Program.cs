using System;
namespace URLShortener;
public class Program
{

    public static void Main(string[] args)
    {

        URLShortener shrtener = new URLShortener();
        shrtener.MapUrl("youtube");
        shrtener.MapUrl("google.com");
        shrtener.PrintMappings();
    }
}

