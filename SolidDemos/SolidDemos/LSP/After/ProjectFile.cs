namespace SolidDemos.LSP.After
{
    public class ProjectFile
    {
        public string FilePath { get; set; }

        public byte[] FileData { get; set; }

        public void LoadFileData()
        {
            // Retrieve FileData from disk
        }
    }
}