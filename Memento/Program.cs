using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            //memoryden gelir
            //amac bir nesne deisiklige ugradikdan sora arzu edildiyinde eski haline salinmakdir
            Book book = new Book()
            {
                Ispn = "1111",
                Author = "viktor",
                Title = "sefiller"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();
            book.Ispn = "112333";
            book.ShowBook();
            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

        }


        class Book
        {
            private string _title;
            private string _author;
            private string _ispn;
            private DateTime _lastEdited;
            public string Title
            {
                get { return _title; }
                set {
                    _title = value;
                    setLastEdited();
                }

            }
            public string Author
            {
                get { return _author; }
                set {
                    _author = value;
                    setLastEdited();
                }

            }
            public string Ispn
            {
                get { return _ispn; }
                set {
                    _ispn = value;
                    setLastEdited();
                }
            }

            private void setLastEdited()
            {
                _lastEdited = DateTime.UtcNow;
            }

            public Memento CreateUndo()
            {
                return new Memento(_ispn, _author, _title, _lastEdited);
            }

            public void RestoreFromUndo(Memento memento)
            {
                _author = memento.Author;
                _ispn = memento.Ispn;
                _title = memento.Title;
                _lastEdited = memento.LastEdited;
            }

            public void ShowBook()
            {
                Console.WriteLine("{0},{1},{2} edited:{3}", Ispn, Title, Author, _lastEdited);
            }

        }

        class Memento 
        {
            public string Ispn { get; set; }
            public string Title { get; set; }

            public string Author { get; set; }

            public DateTime LastEdited { get; set; }

            public Memento(string _ispn,string _title,string _author, DateTime _lastEdited)
            {
                Ispn = _ispn;
                Title = _title;
                Author = _author;
                LastEdited = _lastEdited;
            }
        }

        class CareTaker
        {

            public Memento Memento { get; set; }
        }


       


    }
}
