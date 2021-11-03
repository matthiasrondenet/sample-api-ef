namespace Infrastructure.Email{public interface IEmailSender{void Send(string to, string from, string subject, string body);}public class EmailSender : IEmailSender{public void Send(string to, string from, string subject, string body){ 
// real implementation of a smtp mail sender ..
}}}