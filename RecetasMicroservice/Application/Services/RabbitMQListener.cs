using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RecetasMicroservice.Application.DTOs;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace RecetasMicroservice.Application.Services
{
    public class RabbitMQListener
    {
        private readonly IRecetaService _recetaService;
        private readonly string _hostName;
        private readonly int _port;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _virtualHost;
        private readonly string _queueName;

        public RabbitMQListener(IRecetaService recetaService)
        {
            _recetaService = recetaService;
            _hostName = ConfigurationManager.AppSettings["RabbitMQ_Host"];
            _port = int.Parse(ConfigurationManager.AppSettings["RabbitMQ_Port"]);
            _userName = ConfigurationManager.AppSettings["RabbitMQ_Username"];
            _password = ConfigurationManager.AppSettings["RabbitMQ_Password"];
            _virtualHost = ConfigurationManager.AppSettings["RabbitMQ_VirtualHost"];
            _queueName = ConfigurationManager.AppSettings["RabbitMQ_QueueName"];
        }

        public void StartListening()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = _port,
                UserName = _userName,
                Password = _password,
                VirtualHost = _virtualHost
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var receta = JsonConvert.DeserializeObject<RecetaDTO>(message);

                    // Procesar la receta recibida
                    await HandleReceta(receta);
                };

                channel.BasicConsume(queue: _queueName,
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine(" [*] Esperando mensajes. Presione [enter] para salir.");
                Console.ReadLine();
            }
        }

        private async Task HandleReceta(RecetaDTO receta)
        {
            Console.WriteLine($" [x] Recibido receta para Cita ID: {receta.IdCita}, Paciente: {receta.Paciente}");
            _recetaService.Create(receta);
        }
    }
}