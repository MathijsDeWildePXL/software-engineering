using XMasLights.States;

namespace XMasLights
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== State Pattern - Christmas Lights ===\n");

            var lights = new XMasLight();

            // Test scenario 1: Turn on and cycle through modes
            Console.WriteLine("--- Scenario 1: Power On and Mode Cycling ---");
            lights.SwitchPowerOn();
            lights.PushMode(); // AllOn -> Blinking
            lights.PushMode(); // Blinking -> Starlight
            lights.PushMode(); // Starlight -> Wave
            lights.PushMode(); // Wave -> AllOn (cycle complete)
            Console.WriteLine();

            // Test scenario 2: Turn off
            Console.WriteLine("--- Scenario 2: Power Off ---");
            lights.SwitchPowerOff();
            Console.WriteLine();

            // Test scenario 3: Try mode switch while off
            Console.WriteLine("--- Scenario 3: Try Mode Switch While Off ---");
            lights.PushMode(); // Should not work
            Console.WriteLine();

            // Test scenario 4: Turn on again
            Console.WriteLine("--- Scenario 4: Power On Again ---");
            lights.SwitchPowerOn();
            lights.PushMode(); // AllOn -> Blinking
            lights.PushMode(); // Blinking -> Starlight
            lights.SwitchPowerOff();
            Console.WriteLine();

            // Test scenario 5: Invalid operations
            Console.WriteLine("--- Scenario 5: Invalid Operations ---");
            lights.SwitchPowerOff(); // Already off
            lights.SwitchPowerOn();
            lights.SwitchPowerOn(); // Already on
            Console.WriteLine();

            Console.WriteLine("✅ Benefits of State Pattern:");
            Console.WriteLine("   - No more complex switch statements");
            Console.WriteLine("   - Each state encapsulated in its own class");
            Console.WriteLine("   - Easy to add new states");
            Console.WriteLine("   - Follows Open/Closed Principle");
            Console.WriteLine("   - State transitions are clear and explicit");
        }
    }
}
