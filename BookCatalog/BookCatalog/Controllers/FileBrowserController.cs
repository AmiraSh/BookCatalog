namespace BookCatalog.Controllers
{
    #region Using
    using System.IO;
    using Kendo.Mvc.UI;
    #endregion

    /// <summary>
    /// Controller for storing files.
    /// </summary>
    public class FileBrowserController : EditorFileBrowserController
    {
        /// <summary>
        /// Content folder.
        /// </summary>
        private const string ContentFolderRoot = "~/Content/";

        /// <summary>
        /// Folder to store user files.
        /// </summary>
        private const string FolderName = "Files/";

        /// <summary>
        /// Folders to copy.
        /// </summary>
        private static readonly string[] FoldersToCopy = new[] { "~/Content/shared/" };


        /// <summary>
        /// Gets the base paths from which content will be served.
        /// </summary>
        public override string ContentPath
        {
            get
            {
                return CreateUserFolder();
            }
        }

        /// <summary>
        /// Gets the valid file extensions by which served files will be filtered.
        /// </summary>
        public override string Filter
        {
            get
            {
                return "*.txt, *.doc, *.docx, *.xls, *.xlsx, *.ppt, *.pptx, *.zip, *.rar, *.jpg, *.jpeg, *.gif, *.png";
            }
        }

        /// <summary>
        /// Creates the folder to store to.
        /// </summary>
        /// <returns>Folder path.</returns>
        private string CreateUserFolder()
        {
            var virtualPath = Path.Combine(ContentFolderRoot, "UserFiles", FolderName);

            var path = Server.MapPath(virtualPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                foreach (var sourceFolder in FoldersToCopy)
                {
                    CopyFolder(Server.MapPath(sourceFolder), path);
                }
            }
            return virtualPath;
        }

        /// <summary>
        /// Copies folder with uploaded files.
        /// </summary>
        /// <param name="source">Source path.</param>
        /// <param name="destination">Destination path.</param>
        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(file));
                System.IO.File.Copy(file, dest);
            }

            foreach (var folder in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(folder));
                CopyFolder(folder, dest);
            }
        }
    }
}