using System.Net.Mail;
using System.Net;
using System;
using System.Text;

namespace SentMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string mail = "sicgang.server@gmail.com";
            string pass = "";
            string receiver = "thientai12a7@gmail.com";
            string subject = "Ở nhà chán quá không biết làm gì phải không?";
            string content = "Nếu bạn chán quá thì chúng tôi có món quà dành cho bạn nè :v";
            string signature = "<div dir=\"ltr\" class=\"gmail_signature\" data-smartmail=\"gmail_signature\"><div dir=\"ltr\"><div>--&nbsp;<br></div><div dir=\"ltr\"><div dir=\"ltr\"><div><div dir=\"ltr\"><i><font face=\"garamond, serif\" > \"Sinh viên giúp sinh viên làm chủ công nghệ\"</font></i></div><div dir=\"ltr\"><font face=\"garamond, serif\">-----------------------------------------------------------------</font></div><div><font face=\"garamond, serif\">CLB Tin Học Sinh Viên - Trường Đại Học Thủy Lợi</font></div></div><div>Facebook: <a href=\"http://www.facebook.com/clbtinhocsinhvien\" target=\"_blank\">CLB Tin học sinh viên - Student Informatic Club</a></div></div></div></div></div>";
            var attachedFiles = new Attachment("av.png");

            SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
            mailclient.EnableSsl = true;
            mailclient.Credentials = new NetworkCredential(mail, pass);

            MailMessage message = new MailMessage(mail, receiver);
            message.IsBodyHtml = true;

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Console.Write($"Sendding mail[index:{i}] from {mail} to {receiver}: Ở nhà chán quá phải không... ");

                    message.Subject = $"{subject} [index:{i}]";
                    message.Body = content + signature;

                    //message.CC.Add(_cc.ToString());

                    //message.Bcc.Add(_bcc.ToString());

                    //message.Attachments.Add(attachedFiles);

                    mailclient.Send(message);

                    Console.WriteLine("Ok");
                }
                catch { Console.WriteLine("Fail"); }
            }
        }
    }
}