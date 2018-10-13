using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendMsg : MonoBehaviour {
    public string MassegeSendTo = "vladsk.panchenko.97@gmail.com";
    public string MassegeSendBy = ""; // write your Email
    public string MassegeSendByPassword = "";// write your password 
    public string HeadThemeMsg= "Test My APP";
    public string MsgText = "hi, i send msg to your email ^_^";
    public void Send()
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.Subject = HeadThemeMsg;
        mailMessage.Body = MsgText;
        mailMessage.From = new MailAddress(MassegeSendBy);
        mailMessage.To.Add(MassegeSendTo);
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.Credentials = new NetworkCredential(mailMessage.From.Address, MassegeSendByPassword);
        client.EnableSsl = true;

        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

        client.Send(mailMessage);
        Debug.Log("Success, email sent through SMTP!");
    }
}
