namespace CitasMicroservice.Application.Services
{
    public interface IRabbitMQSender
    {
        void SendMessage(object message);
    }
}