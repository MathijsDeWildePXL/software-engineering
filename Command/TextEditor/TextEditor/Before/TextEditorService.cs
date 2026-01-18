using System;

namespace TextEditor.Before
{
    // PROBLEM: Direct coupling, no undo/redo support
    // Editor directly manipulates the document
    
    public class Document
    {
        public string Content { get; set; } = "";

        public void AddText(string text)
        {
            Content += text;
            Console.WriteLine($"Added: '{text}' -> Content: '{Content}'");
        }

        public void DeleteLastCharacter()
        {
            if (Content.Length > 0)
            {
                Content = Content.Substring(0, Content.Length - 1);
                Console.WriteLine($"Deleted last character -> Content: '{Content}'");
            }
        }
    }

    public class Editor
    {
        private Document _document;

        public Editor(Document document)
        {
            _document = document;
        }

        public void Type(string text)
        {
            _document.AddText(text);
        }

        public void Delete()
        {
            _document.DeleteLastCharacter();
        }

        // Problems:
        // ❌ No undo/redo functionality
        // ❌ Can't queue commands
        // ❌ Can't log command history
        // ❌ Tight coupling between editor and document
    }
}
