using System;
using System.Collections.Generic;

namespace L.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //araci uzlastirici
            //kullanisli desenlerden biridir arabulucu demekdir
            // bu desenin gorevi farki sistemleri bir biri ile gorusturme gorevi uslenmesidir
            Mediator mediator = new Mediator();
        Teacher engin = new Teacher(mediator);
            engin.Name = "engin";
            mediator.Teacher = engin;

            Student salih = new Student(mediator);
            salih.Name = "salih";
            Student derin = new Student(mediator);
            derin.Name = "derin";
            mediator.Students = new List<Student>() { salih, derin };
            engin.SendNewImageUrl("slide1.jpg");
            engin.RecieveQuestion("soru", derin);
            Console.ReadLine();



        }

        abstract class CourseMember
        {
            protected Mediator Mediator;
            protected CourseMember(Mediator mediator)
            {
                Mediator = mediator;
            }

        }

        class Teacher : CourseMember
        {

            public Teacher(Mediator mediator):base(mediator)
            {

            }

            public void RecieveQuestion(string question, Student student)
            {

                Console.WriteLine("Teacher recived a questin from {0},{1}",student.Name,question);

            }
            public string Name { get; set; }

            public void SendNewImageUrl(string url)
            {
                Console.WriteLine("Teacher changed slide : {0}", url);
                Mediator.UpdateImage(url);
            }
            public void AnswerQuestion(string answer,Student student)
            {
                Console.WriteLine("teacher answered question {0},{1}", student.Name, answer);
            }

        }
        class Student : CourseMember
        {
            public Student(Mediator mediator) : base(mediator)
            {

            }
            public string Name { get;  set; }

            public void RecieveImage(string url)
            {
                Console.WriteLine("student recieve image:{0}", url);
            }

            public void RecieveAnswer(string answer)
            {
                Console.WriteLine("student recive answr:{0}", answer);
            }
        }

        class Mediator
        {
            public Teacher Teacher { get; set; }

            public List<Student> Students { get; set; }

            public void UpdateImage(string url)
            {
                foreach (var student in Students)
                {
                    student.RecieveImage(url);
                }
            }

            public void SendQuestion(string question,Student student)
            {
                Teacher.RecieveQuestion(question, student);
            }

            public void SendAnsver(string answer,Student student)
            {
                student.RecieveAnswer(answer);
            }
        }

    }
}
