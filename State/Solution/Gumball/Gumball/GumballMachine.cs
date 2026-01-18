using System.Text;

namespace Gumball.States
{
    // State Pattern Implementation - AFTER Refactoring
    
    // State Interface
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
        void Refill();
    }

    // Context - GumballMachine
    public class GumballMachine
    {
        public IState SoldOutState { get; }
        public IState NoQuarterState { get; }
        public IState HasQuarterState { get; }
        public IState SoldState { get; }

        public IState CurrentState { get; set; }
        public int Count { get; set; }

        public GumballMachine(int numberGumballs)
        {
            SoldOutState = new SoldOutState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            SoldState = new SoldState(this);

            Count = numberGumballs;
            CurrentState = numberGumballs > 0 ? NoQuarterState : SoldOutState;
        }

        public void InsertQuarter() => CurrentState.InsertQuarter();
        public void EjectQuarter() => CurrentState.EjectQuarter();
        public void TurnCrank()
        {
            CurrentState.TurnCrank();
            CurrentState.Dispense();
        }

        public void Refill(int count)
        {
            Count = count;
            Console.WriteLine($"The gumball machine was just refilled; it's new count is: {Count}");
            CurrentState.Refill();
        }

        public void ReleaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot...");
            if (Count > 0)
            {
                Count--;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\nMighty Gumball, Inc.");
            result.Append("\nC#-enabled Standing Gumball Model #2016 (State Pattern)");
            result.Append("\nInventory: " + Count + " gumball");
            if (Count != 1)
            {
                result.Append("s");
            }
            result.Append("\n");
            result.Append("Machine is " + CurrentState.GetType().Name);
            result.Append("\n");
            return result.ToString();
        }
    }

    // Concrete States
    public class SoldOutState : IState
    {
        private readonly GumballMachine _gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there are no gumballs");
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void Refill()
        {
            _gumballMachine.CurrentState = _gumballMachine.NoQuarterState;
        }
    }

    public class NoQuarterState : IState
    {
        private readonly GumballMachine _gumballMachine;

        public NoQuarterState(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You inserted a quarter");
            _gumballMachine.CurrentState = _gumballMachine.HasQuarterState;
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there's no quarter");
        }

        public void Dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public void Refill()
        {
            // Stay in NoQuarterState
        }
    }

    public class HasQuarterState : IState
    {
        private readonly GumballMachine _gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
            _gumballMachine.CurrentState = _gumballMachine.NoQuarterState;
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            _gumballMachine.CurrentState = _gumballMachine.SoldState;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void Refill()
        {
            // Stay in HasQuarterState
        }
    }

    public class SoldState : IState
    {
        private readonly GumballMachine _gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumball");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball!");
        }

        public void Dispense()
        {
            _gumballMachine.ReleaseBall();
            if (_gumballMachine.Count > 0)
            {
                _gumballMachine.CurrentState = _gumballMachine.NoQuarterState;
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs!");
                _gumballMachine.CurrentState = _gumballMachine.SoldOutState;
            }
        }

        public void Refill()
        {
            // Can't refill while dispensing
        }
    }
}
