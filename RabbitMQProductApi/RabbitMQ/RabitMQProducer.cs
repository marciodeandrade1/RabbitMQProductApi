using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;


namespace RabbitMQProductApi.RabbitMQ

{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            //aqui especificamos o RabbitMQ Server
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //cria a conexão usando connection factory
            var connection = factory.CreateConnection();

            using var chanel = connection.CreateModel();


            chanel.QueueDeclare("product", exclusive: false);
            
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            chanel.BasicPublish(exchange: "", routingKey: "product", body: body);


        }
    }
}
