using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace isRock.Template
{
    public class LineWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        [Route("api/LineBotWebHook")]
        [HttpPost]
        public IActionResult POST()
        {
            var AdminUserId = "U4c19f45817714d759f077ff9368f2a63";
            // int number=(new Random()).Next(1,100);
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
                    var id = LineEvent.source.userId;
                    var userInfo = this.GetUserInfo(id);
                    responseMsg = $"{userInfo.displayName}({id})說了:{LineEvent.message.text}";
                }
                else if (LineEvent.type.ToLower() == "message")

                    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                else
                    responseMsg = $"收到 event : {LineEvent.type} ";
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