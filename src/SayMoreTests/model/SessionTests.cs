using System.IO;
using System.Linq;
using NUnit.Framework;
using Palaso.TestUtilities;
using SayMore.Model;
using SayMore.Model.Files;

namespace SayMoreTests.Model
{
	[TestFixture]
	public class SessionTests
	{
		private TemporaryFolder _parentFolder;

		[SetUp]
		public void Setup()
		{
			_parentFolder = new TemporaryFolder("sessionTest");
		}

		[TearDown]
		public void TearDown()
		{
			_parentFolder.Dispose();
			_parentFolder = null;
		}

		private Session CreateSession(string id)
		{
			return new Session(_parentFolder.Path, id, ComponentFile.CreateMinimalComponentFileForTests,
				new FileSerializer(), new SessionFileType(() => null));
		}

		/*  THIS IS EMPTY BECAUSE MOST OF THE BEHAVIOR THUS FAR IS IN THE BASE CLASS, AND TESTED
		 * THERE, INSTEAD
		 */
	}
}
