using System;

namespace H.State
{
    class Program
    {
        static void Main(string[] args)
        {
            // bir nesnenin bir olayin movcut durumunu kontrol etmek icindir
            Context context = new Context();
            ModifiedState modifiedState = new ModifiedState();
            modifiedState.doAction(context);
            Console.WriteLine(context.GetState().ToString());
            DeletedState deletedState = new DeletedState();
            deletedState.doAction(context);
            Console.WriteLine(context.GetState().ToString());
            AddeddState addeddState = new AddeddState();
            addeddState.doAction(context);
            Console.WriteLine(context.GetState().ToString());
            Console.ReadLine();
        }

        interface IState
        {
            void doAction(Context context);
        }


        class ModifiedState : IState
        {
            public void doAction(Context context)
            {
                Console.WriteLine("State:Modified");
                context.SetState(this);
            }
            public override string ToString()
            {
                return "Modified";
            }
        }

        class DeletedState : IState
        {
            public void doAction(Context context)
            {
                Console.WriteLine("State:Deleted");
                context.SetState(this);
            }
            public override string ToString()
            {
                return "deleted";
            }
        }

        class AddeddState : IState
        {
            public void doAction(Context context)
            {
                Console.WriteLine("State:Added");
                context.SetState(this);
            }
        }




        class Context
        {
            private IState _state;

            public void SetState(IState state)
            {
                _state = state;
            }
            public IState GetState()
            {
                return _state;
            }

        }
    }
}
