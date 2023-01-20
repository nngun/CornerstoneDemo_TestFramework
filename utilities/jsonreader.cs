using System;
using Newtonsoft.Json.Linq;

namespace E2X_test_framework.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }


        public string extractData(String tokenName)
        {

            String myJsonString = File.ReadAllText("/Users/nurtengun/Projects/testautomation/E2X_test_framework/utilities/TestData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();


        }


        }
 }


