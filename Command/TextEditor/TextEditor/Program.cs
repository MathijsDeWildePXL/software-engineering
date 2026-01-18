using System;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE: No Undo/Redo Support ===\n");
            DemoBefore();

            Console.WriteLine("\n\n=== AFTER: Command Pattern with Undo/Redo ===\n");
            DemoAfter();
        }

        static void DemoBefore()
        {
            var document = new Before.Document();
            var editor = new Before.Editor(document);

            editor.Type("Hello");
            editor.Type(" ");
            editor.Type("World");
            editor.Delete();

            Console.WriteLine($"\nFinal content: '{document.Content}'");
            Console.WriteLine("\n❌ Problem: No way to undo or redo operations!");
        }

        static void DemoAfter()
        {
            var document = new After.Document();
            var editor = new After.Editor();

            // Execute commands
            editor.ExecuteCommand(new After.AddTextCommand(document, "Hello"));
            editor.ExecuteCommand(new After.AddTextCommand(document, " "));
            editor.ExecuteCommand(new After.AddTextCommand(document, "World"));
            editor.ExecuteCommand(new After.DeleteTextCommand(document));

            Console.WriteLine($"\nCurrent content: '{document.Content}'");
            Console.WriteLine($"Undo stack size: {editor.UndoStackSize}");

            // Undo operations
            Console.WriteLine("\n--- Undoing last 2 operations ---");
            editor.Undo();
            editor.Undo();

            Console.WriteLine($"\nCurrent content: '{document.Content}'");
            Console.WriteLine($"Undo stack size: {editor.UndoStackSize}");
            Console.WriteLine($"Redo stack size: {editor.RedoStackSize}");

            // Redo operations
            Console.WriteLine("\n--- Redoing operations ---");
            editor.Redo();

            Console.WriteLine($"\nCurrent content: '{document.Content}'");
            Console.WriteLine($"Undo stack size: {editor.UndoStackSize}");
            Console.WriteLine($"Redo stack size: {editor.RedoStackSize}");

            // Test undo all
            Console.WriteLine("\n--- Undoing all operations ---");
            while (editor.UndoStackSize > 0)
            {
                editor.Undo();
            }
            editor.Undo(); // Try one more (should say nothing to undo)

            Console.WriteLine($"\nFinal content: '{document.Content}'");
            Console.WriteLine("\n✅ Solution: Full undo/redo support with command history!");
        }
    }
}
