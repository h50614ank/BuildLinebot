using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace isRock.Template
{
    public class LineWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        [Route("api/LineBotWebHook")]
        [HttpPost]
        public IActionResult POST()
        {
            var AdminUserId = "U4c19f45817714d759f077ff9368f2a63";

            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = "oHmnd2BIqfoREJemLotrk9J6E2idV1x1ULY3Bfl6PJbEg82VHzTR2UGvtG5DRvv9YDP1aB+A2aZ07ImFv8265UlPRFMYDEmG5ctQvYSvp/AHiF+cpRjM0JUvZNW2opg80sSvqubWGoKSjn0URVw/EAdB04t89/1O/w1cDnyilFU=";
                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                var responseMsg = "";
                //準備回覆訊息
                if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                {
                    var LuisRet = CallLUIS(LineEvent.message.text);
                    responseMsg = $"判斷目的 : {LuisRet.prediction.topIntent}";
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
        public dynamic CallLUIS(string message)
        {
            string endpoint = "https://westus.api.cognitive.microsoft.com/luis/prediction/v3.0/apps/ddce2c6c-cef5-4d11-9fd6-dfe43addfa61/slots/production/predict?subscription-key=f9d5dd2a31864e07b0e9734069a63e69&verbose=true&show-all-intents=true&log=true&query=";
            var client = new HttpClient();
            var endpointUri = endpoint + message;
            var response = client.GetAsync(endpointUri).Result;
            //get JSON
            var JSON = response.Content.ReadAsStringAsync().Result;
            //反序列化 JSON to Object
            var Result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(JSON);
            return Result;
        }
    }

}