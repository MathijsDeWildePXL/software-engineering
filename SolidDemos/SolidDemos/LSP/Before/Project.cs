using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SolidDemos.LSP.Before
{
    public class Project
    {
        public Collection<ProjectFile> ProjectFiles { get; set; }

        public void LoadAllFiles()
        {
            foreach (ProjectFile file in ProjectFiles)
            {
                file.LoadFileData();
            }
        }

        public void SaveAllFiles()
        {
            foreach (ProjectFile file in ProjectFiles)
            {
                // Why do we need to add this?
                // if (file as ReadOnlyFile == null) 
                file.SaveFileData();
            }
        }
    }
}
