using Microsoft.Azure.Functions.Worker;

namespace ReceieveCityName
{
    public class Function1
    {
        [Function("Function1")]
        public void Run([ServiceBusTrigger(topicName: "aztrainingtaktuk_topic", subscriptionName: "sub1", Connection = "ServiceBusConnectionString")] string mySbMsg,
            [CosmosDB(
            databaseName: "WeatherInfo",
            containerName:"CityWeather",
            Connection = "CosmosDBConnectionString"
            )] out dynamic document)
        {
            document = new { Description = mySbMsg, Guid = new Guid() };
        }
    }
}
