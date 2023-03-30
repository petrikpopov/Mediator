using System;

namespace Mediator_30._03._2023
{
    class Program
    {
        public abstract class Mediator
        {
            public abstract void SendMess(string sms , Chat dispatcher);
        }
        public abstract class Chat
        {
            Mediator mediator { set; get; }

            public Chat(Mediator m)
            {
                mediator = m;
            }

            public abstract void Notify(string value);
            
        }
        public class Airplane:Chat
        {

            public Airplane(Mediator mediator) : base(mediator)
            {

            }
            public override void Notify(string value)
            {
                Console.WriteLine($"Сообщение для самолета:{value}");
            }
        }
        public class Helicopter : Chat
        {
            public Helicopter(Mediator mediator) : base(mediator)
            {

            }
            public override void Notify(string value)
            {
                Console.WriteLine($"Сообщение для вертолета :{value}");
            }
        }
        public class Rocket : Chat
        {
            public Rocket(Mediator mediator) : base(mediator)
            {

            }
            public override void Notify(string value)
            {
                Console.WriteLine($"Сообщение для ракеты:{value}");
            }
        }
        public class Dispatcher : Mediator
        {
            public Chat airplane { set; get; }
            public Chat rocket { set; get; }
            public Chat helicopter { set; get; }

            public Dispatcher() { }

            public override void SendMess(string sms, Chat dispatcher)
            {
                if (airplane == dispatcher)
                {
                    airplane.Notify(sms);
                }
                else if (rocket == dispatcher)
                {
                    rocket.Notify(sms);
                }
                else if (helicopter == dispatcher)
                {
                    helicopter.Notify(sms);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Dispatcher dispatcher = new Dispatcher();
            Chat chat_airplane = new Airplane(dispatcher);
            Chat chat_helicopter = new Helicopter(dispatcher);
            Chat chat_rocket = new Rocket(dispatcher);
            chat_airplane.Notify("Разрешаю на пасадку");
            chat_helicopter.Notify("На второй круг и  на пасадку ");
            chat_rocket.Notify("Полети и забери Илона, потом вернешься ");
        }
    }
}
