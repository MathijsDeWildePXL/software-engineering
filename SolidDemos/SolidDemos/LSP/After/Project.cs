using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SolidDemos.LSP.After
{
    public class Project
    {
        public Collection<ProjectFile> AllFiles { get; set; }

        public void LoadAllFiles()
        {
            foreach (ProjectFile file in AllFiles)
            {
                file.LoadFileData();
            }
        }

        public void SaveAllFiles()
        {
            foreach (WriteableFile file in AllFiles.OfType<WriteableFile>())
            {
                file.SaveFileData();
            }
        }
    }
}
