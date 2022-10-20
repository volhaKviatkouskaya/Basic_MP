using FileSystemSearch;
using Moq;

// for testing use folder which was prepared in advance 

namespace FileSystemSearchTest
{
    [TestClass]
    public class FileSystemSearchTest
    {
        [TestMethod]
        [DataRow(ActionType.KeepItem, "TestFolder", 6)]
        public void SelectAllFromSearch(ActionType action, string path, int expected)
        {
            FileSystemVisitor fileSystemVisitor = new();
            fileSystemVisitor.StartEvent += () => { };
            fileSystemVisitor.FinishEvent += () => { };
            fileSystemVisitor.FoundItem += (x) => { };
            fileSystemVisitor.FoundFilteredItem += (x) => { return action; };

            var array = fileSystemVisitor.Search(path);
            var actual = array.Count;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [DataRow(ActionType.KeepItem, "TestFolder", 4)]
        public void SelectAllFilesFromSearch(ActionType action, string path, int expected)
        {
            Predicate<SearchedItem> filter = new(x => !x.IsFolder);
            FileSystemVisitor fileSystemVisitor = new(filter);
            fileSystemVisitor.StartEvent += () => { };
            fileSystemVisitor.FinishEvent += () => { };
            fileSystemVisitor.FoundItem += (x) => { };
            fileSystemVisitor.FoundFilteredItem += (x) => { return action; };

            var array = fileSystemVisitor.Search(path);
            var actual = array.Count;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [DataRow(ActionType.KeepItem, "TestFolder", 2)]
        public void SearchDocFiles(ActionType action, string path, int expected)
        {
            Predicate<SearchedItem> filter = new(x => x.FileType == ".DOC");
            FileSystemVisitor fileSystemVisitor = new(filter);
            fileSystemVisitor.StartEvent += () => { };
            fileSystemVisitor.FinishEvent += () => { };
            fileSystemVisitor.FoundItem += (x) => { };
            fileSystemVisitor.FoundFilteredItem += (x) => { return action; };

            var array = fileSystemVisitor.Search(path);
            var actual = array.Count;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [DataRow(ActionType.KeepItem, "TestFolder", 2)]
        public void SelectAllFolders(ActionType action, string path, int expected)
        {
            Predicate<SearchedItem> filter = new(x => x.IsFolder);
            FileSystemVisitor fileSystemVisitor = new(filter);
            fileSystemVisitor.StartEvent += () => { };
            fileSystemVisitor.FinishEvent += () => { };
            fileSystemVisitor.FoundItem += (x) => { };
            fileSystemVisitor.FoundFilteredItem += (x) => { return action; };

            var array = fileSystemVisitor.Search(path);
            var actual = array.Count;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [DataRow(ActionType.ExcludeItem, "TestFolder", 0)]
        public void ExcludeAllFoldersFromSearch(ActionType action, string path, int expected)
        {
            Predicate<SearchedItem> filter = new(x => x.IsFolder);
            FileSystemVisitor fileSystemVisitor = new(filter);
            fileSystemVisitor.StartEvent += () => { };
            fileSystemVisitor.FinishEvent += () => { };
            fileSystemVisitor.FoundItem += (x) => { };
            fileSystemVisitor.FoundFilteredItem += (x) => { return action; };

            var array = fileSystemVisitor.Search(path);
            var actual = array.Count;

            Assert.IsTrue(actual == expected);
        }
    }
}