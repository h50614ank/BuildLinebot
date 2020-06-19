using System;
using System.Collections.Generic;

namespace ConfirmTempalteMessage1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new isRock.LineBot.Bot("u0XYR8+uaGyXkdw39oaoFw5cU93SvzdTZqWVQNO5UFsc1A3MJJHayHFxI1skGv4J5YPrlO+sgfn9nWUofSVYXf8tUtzucGpxAWDomJFWpQJ+Fo0lwOFk+bTF6Xzz8nY7BNZuJlQdXQbphnXPds8E/gdB04t89/1O/w1cDnyilFU=");
            var act2 = new List<isRock.LineBot.TemplateActionBase>();
          

            act2.Add(new isRock.LineBot.PostbackAction()
            { label = "YES", data ="YES" });

            act2.Add(new isRock.LineBot.PostbackAction()
            { label = "NO", data = "NO" });
          
            // act.Add(new isRock.LineBot.UriAction
            var ComfirmTemplate = new isRock.LineBot.ConfirmTemplate()
            {
                text = "ComfirmTemplate文字訊息",
                //設定Actions
                actions = act2 //設定actions回覆動作
            };
            bot.PushMessage("U4c19f45817714d759f077ff9368f2a63", ComfirmTemplate);
        }
    }
}
