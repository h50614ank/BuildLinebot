using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace test1
{
    class Program
    {
        static string endpoint="https://westus.api.cognitive.microsoft.com/luis/prediction/v3.0/apps/ddce2c6c-cef5-4d11-9fd6-dfe43addfa61/slots/production/predict?subscription-key=f9d5dd2a31864e07b0e9734069a63e69&verbose=true&show-all-intents=true&log=true&query=";
        static void Main(string[] args)
        {
            var client=new HttpClient();
            var endpointUri=endpoint+="珍奶微糖少冰";
            var response=client.GetAsync(endpointUri).Result;
            var JSON=response.Content.ReadAsStringAsync().Result;
            var Result=Newtonsoft.Json.JsonConvert.DeserializeObject<LuisResult>(JSON);
            Console.WriteLine("topIntent :"+Result.prediction.topIntent);
        }
    }
#region "Model"
   public class 點餐行為
    {
        public double score { get; set; }
    }

    public class 客訴行為
    {
        public double score { get; set; }
    }

    public class None
    {
        public double score { get; set; }
    }

    public class 訂票
    {
        public double score { get; set; }
    }

    public class Intents
    {
        public 點餐行為 點餐行為 { get; set; }
        public 客訴行為 客訴行為 { get; set; }
        public None None { get; set; }
        public 訂票 訂票 { get; set; }
    }

    public class Entities
    {
        public IList<string> 餐點名稱 { get; set; }
    }

    public class Prediction
    {
        public string topIntent { get; set; }
        public Intents intents { get; set; }
        public Entities entities { get; set; }
    }
    public class LuisResult
    {
        public string query { get; set; }
        public Prediction prediction { get; set; }
    }
#endregion
}