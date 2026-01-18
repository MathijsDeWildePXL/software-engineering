using System;
using System.Collections.Generic;

namespace TextEditor.After
{
    // SOLUTION: Command Pattern - encapsulate requests as objects
    
    // Receiver
    public class Document
    {
        public string Content { get; set; } = "";

        public void AddText(string text)
        {
            Content += text;
        }

        public void RemoveText(int count)
        {
            if (Content.Length >= count)
            {
                Content = Content.Substring(0, Content.Length - count);
            }
        }
    }

    // Command interface
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Concrete command - Add Text
    public class AddTextCommand : ICommand
    {
        private readonly Document _document;
        private readonly string _text;

        public AddTextCommand(Document document, string text)
        {
            _document = document;
            _text = text;
        }

        public void Execute()
        {
            _document.AddText(_text);
            Console.WriteLine($"Executed: Add '{_text}' -> Content: '{_document.Content}'");
        }

        public void Undo()
        {
            _document.RemoveText(_text.Length);
            Console.WriteLine($"Undone: Remove '{_text}' -> Content: '{_document.Content}'");
        }
    }

    // Concrete command - Delete Text
    public class DeleteTextCommand : ICommand
    {
        private readonly Document _document;
        private string _deletedText = "";

        public DeleteTextCommand(Document document)
        {
            _document = document;
        }

        public void Execute()
        {
            if (_document.Content.Length > 0)
            {
                _deletedText = _document.Content[^1].ToString();
                _document.RemoveText(1);
                Console.WriteLine($"Executed: Delete '{_deletedText}' -> Content: '{_document.Content}'");
            }
        }

        public void Undo()
        {
            _document.AddText(_deletedText);
            Console.WriteLine($"Undone: Add back '{_deletedText}' -> Content: '{_document.Content}'");
        }
    }

    // Invoker - Editor with undo/redo support
    public class Editor
    {
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // Clear redo stack when new command is executed
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
            }
        }

        public int UndoStackSize => _undoStack.Count;
        public int RedoStackSize => _redoStack.Count;
    }

    // Benefits:
    // ✅ Undo/Redo functionality
    // ✅ Command history
    // ✅ Decoupled sender and receiver
    // ✅ Easy to add new commands
    // ✅ Can queue/schedule commands
}
