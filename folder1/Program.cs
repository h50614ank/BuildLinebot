using System;

namespace folder1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var bot = new isRock.LineBot.Bot("u0XYR8+uaGyXkdw39oaoFw5cU93SvzdTZqWVQNO5UFsc1A3MJJHayHFxI1skGv4J5YPrlO+sgfn9nWUofSVYXf8tUtzucGpxAWDomJFWpQJ+Fo0lwOFk+bTF6Xzz8nY7BNZuJlQdXQbphnXPds8E/gdB04t89/1O/w1cDnyilFU=");
            // bot.PushMessage("U4c19f45817714d759f077ff9368f2a63", "顯示訊息");
            // bot.PushMessage("U4c19f45817714d759f077ff9368f2a63", 1, 2);
            // for (int i = 0; i < 10; i++)
            // {
            //     bot.PushMessage("U4c19f45817714d759f077ff9368f2a63", $"NO.{i}");
            //     bot.PushMessage("U4c19f45817714d759f077ff9368f2a63", 1, 1);
            // }
            bot.PushMessage("U4c19f45817714d759f077ff9368f2a63", new Uri("https://imgur.com/bimJBfo.png"));
        }
    }
}
