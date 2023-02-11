using System;

namespace bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //bu desende  amac bir nesnenin icersinde deisdirile bilir kisim varsa
            //onlari soyutlama teknikleri ile gerceklesdirib kullanmakdir
            CustomerManager customer = new CustomerManager();
            customer.messageSender = new MailSend();
           
            customer.UpdateCustomer();
            Console.ReadLine();
        }


    }
    abstract class MessageSenderBase
    {

        public void save()
        {
            Console.WriteLine("mesaj kaydedildi");
        }

        public abstract void send(Body body);

    }
    class SmsSend : MessageSenderBase
    {
        public override void send(Body body)
        {
            Console.WriteLine("{0} was send via Smssender", body.Text);
        }
    }
    class MailSend : MessageSenderBase
    {
        public override void send(Body body)
        {
            Console.WriteLine("{0} was send via Mailsender", body.Text);
        }
    }

    public class Body
    {
        public string Title { get; set; }

        public string Text { get; set; }


    }

    class CustomerManager
    {
        public  MessageSenderBase messageSender { get; set; }

        public void UpdateCustomer()
        {
            messageSender.send(new Body { Title = "aaa",Text="vvv" });
            Console.WriteLine("update olundu");
        }


    }



}
