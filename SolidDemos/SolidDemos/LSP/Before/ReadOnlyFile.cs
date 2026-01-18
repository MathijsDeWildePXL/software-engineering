using System;

namespace SolidDemos.LSP.Before
{
    public class ReadOnlyFile : ProjectFile
    {
        public override void SaveFileData()
        {
            throw new InvalidOperationException();
        }
    }
}