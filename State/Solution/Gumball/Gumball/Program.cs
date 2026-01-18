using Gumball.States;

namespace Gumball
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== State Pattern - Gumball Machine ===\n");

            var gumballMachine = new GumballMachine(5);

            Console.WriteLine(gumballMachine);

            // Test scenario 1: Normal purchase
            Console.WriteLine("--- Scenario 1: Normal Purchase ---");
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            Console.WriteLine(gumballMachine);

            // Test scenario 2: Insert and eject
            Console.WriteLine("--- Scenario 2: Insert and Eject ---");
            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            gumballMachine.TurnCrank();
            Console.WriteLine(gumballMachine);

            // Test scenario 3: Multiple purchases
            Console.WriteLine("--- Scenario 3: Multiple Purchases ---");
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            Console.WriteLine(gumballMachine);

            // Test scenario 4: Refill
            Console.WriteLine("--- Scenario 4: Refill ---");
            gumballMachine.Refill(10);
            Console.WriteLine(gumballMachine);

            // Test scenario 5: Invalid operations
            Console.WriteLine("--- Scenario 5: Invalid Operations ---");
            gumballMachine.TurnCrank(); // No quarter
            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter(); // Can't insert twice
            gumballMachine.TurnCrank();
            Console.WriteLine(gumballMachine);
        }
    }
}
