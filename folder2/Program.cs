using System;
using System.Collections.Generic;

namespace folder2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new isRock.LineBot.Bot("u0XYR8+uaGyXkdw39oaoFw5cU93SvzdTZqWVQNO5UFsc1A3MJJHayHFxI1skGv4J5YPrlO+sgfn9nWUofSVYXf8tUtzucGpxAWDomJFWpQJ+Fo0lwOFk+bTF6Xzz8nY7BNZuJlQdXQbphnXPds8E/gdB04t89/1O/w1cDnyilFU=");
            var act = new List<isRock.LineBot.TemplateActionBase>();
            act.Add(new isRock.LineBot.UriAction()
            {
                label ="UriAction",
                uri=new Uri("https://www.google.com/")
            });
            act.Add(new isRock.LineBot.PostbackAction(){
                label ="Postback",
                data="abc=aaa&def=111"
            });
            // act.Add(new isRock.LineBot.UriAction)
            var Column1 = new isRock.LineBot.Column()
            {
                text = "Text",
                title = "Title",
                thumbnailImageUrl = new Uri("https://i.imgur.com/TuZRBRR.jpg"),
                actions = act
            };
             var Column = new isRock.LineBot.Column
            {
                text = "ButtonsTemplate文字訊息",
                title = "ButtonsTemplate標題",
                //設定圖片
                thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201706/22-124357-ad3c87d6-b9cc-488a-8150-1c2fe642d237.png"),
                actions = act //設定回覆動作
            };

            //建立CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            //這是範例，所以用一組樣板建立三個
            CarouselTemplate.columns.Add(Column1);
            CarouselTemplate.columns.Add(Column);
            bot.PushMessage("U4c19f45817714d759f077ff9368f2a63",CarouselTemplate);
        }
    }
}
