using System;
namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface IEmailService
    {
        void EnviarCorreoSimulado(string destinatario, string asunto, string cuerpo);
    }

    public class EmailService : IEmailService
    {
        public void EnviarCorreoSimulado(string destinatario, string asunto, string cuerpo)
        {
            // Simulación del envío de correo
            Console.WriteLine("Prueba de envio");
            Console.WriteLine($"Para: {destinatario}");
            Console.WriteLine($"Asunto: {asunto}");
            Console.WriteLine("Contenido:");
            Console.WriteLine(cuerpo);
            Console.WriteLine(" ");
        }
    }
}
