using System;

namespace SolidDemos.LSP.Before
{
    public class ProjectFile
    {
        public string FilePath { get; set; }

        public byte[] FileData { get; set; }

        public void LoadFileData()
        {
            // Retrieve FileData from disk
        }

        public virtual void SaveFileData()
        {
            // Write FileData to disk
        }
    }
}