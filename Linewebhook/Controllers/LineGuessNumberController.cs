using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace isRock.Template
{
    public class LineGuessNumberController : isRock.LineBot.LineWebHookControllerBase
    {
        static int TheNumber=0;
        [Route("api/LineGuessNumber")]
        [HttpPost]
        public IActionResult POST()
        {
            var AdminUserId = "U4c19f45817714d759f077ff9368f2a63";
            Random random = new Random();

            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = "u0XYR8+uaGyXkdw39oaoFw5cU93SvzdTZqWVQNO5UFsc1A3MJJHayHFxI1skGv4J5YPrlO+sgfn9nWUofSVYXf8tUtzucGpxAWDomJFWpQJ+Fo0lwOFk+bTF6Xzz8nY7BNZuJlQdXQbphnXPds8E/gdB04t89/1O/w1cDnyilFU=";
                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                var responseMsg = "";
                //準備回覆訊息
                if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                {
                    var UserMsg = LineEvent.message.text;
                    switch (UserMsg)
                    {
                        case "start":
                            responseMsg="開始";
                            TheNumber=random.Next(1000,9999);
                            break;
                        case "abandon":
                            responseMsg="放棄重來";
                            TheNumber=random.Next(1000,999);
                            break;
                        default:
                            var GuessNumber=int.Parse(UserMsg);
                            if(GuessNumber>TheNumber)responseMsg=$"比{GuessNumber}小一點~~";
                            if(GuessNumber<TheNumber)responseMsg=$"比{GuessNumber}大一點~~";
                            if(GuessNumber==TheNumber)responseMsg=$"猜對了，恭喜你!!答案是{GuessNumber}";
                            break;
                    }
                }
                //回覆訊息
                this.ReplyMessage(LineEvent.replyToken, responseMsg);
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}