using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Palaso.CommandLineProcessing;
using Palaso.Media;
using SayMore.Model.Fields;
using SayMore.Properties;
using SayMore.UI.ComponentEditors;
using SIL.Localization;

namespace SayMore.Model.Files
{
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	/// Each file corresponds to a single kind of fileType.  The FileType then tells
	/// us what controls are available for marking up, editing, or viewing that file.
	/// It also tells us which commands to offer in, for example, a context menu.
	/// </summary>
	/// ----------------------------------------------------------------------------------------
	public class FileType
	{
		protected Func<BasicFieldGridEditor.Factory> _basicFieldGridEditorFactoryLazy;
		protected Func<string, bool> _isMatchPredicate;

		protected readonly Dictionary<int, IEnumerable<IEditorProvider>> _editors =
			new Dictionary<int, IEnumerable<IEditorProvider>>();

		public string Name { get; private set; }
		public virtual string TypeDescription { get; protected set; }
		public virtual Image SmallIcon { get; protected set; }
		public virtual string FileSize { get; protected set; }

		/// ------------------------------------------------------------------------------------
		public static FileType Create(string name, string matchForEndOfFileName)
		{
			return new FileType(name, p => p.EndsWith(matchForEndOfFileName));
		}

		/// ------------------------------------------------------------------------------------
		public static FileType Create(string name, string[] matchesForEndOfFileName)
		{
			return new FileType(name, p => matchesForEndOfFileName.Any(ext => p.EndsWith(ext)));
		}

		/// ------------------------------------------------------------------------------------
		public FileType(string name, Func<string, bool>isMatchPredicate)
		{
			Name = name;
			_isMatchPredicate = isMatchPredicate;
		}

		/// ------------------------------------------------------------------------------------
		public virtual bool IsMatch(string path)
		{
			return _isMatchPredicate(path);
		}

		/// ------------------------------------------------------------------------------------
		public virtual string FieldsGridSettingsName
		{
			get { return "UnknownFileFieldsGrid"; }
		}

		/// ------------------------------------------------------------------------------------
		public virtual IEnumerable<IEditorProvider> GetEditorProviders(int hashCode, ComponentFile file)
		{
			IEnumerable<IEditorProvider> editorList;
			if (!_editors.TryGetValue(hashCode, out editorList))
			{
				editorList = new List<IEditorProvider>(GetNewSetOfEditorProviders(file));
				_editors[hashCode] = editorList;
			}
			else
			{
				foreach (var editor in editorList)
					editor.SetComponentFile(file);
			}

			return editorList;
		}

		/// ------------------------------------------------------------------------------------
		protected virtual IEnumerable<IEditorProvider> GetNewSetOfEditorProviders(ComponentFile file)
		{
			yield return new DiagnosticsFileInfoControl(file);
		}

		/// ------------------------------------------------------------------------------------
		/// <param name="filePath"></param>
		public virtual IEnumerable<FileCommand> GetCommands(string filePath)
		{
			yield return new FileCommand("Show in File Explorer...", FileCommand.HandleOpenInFileManager_Click);
			yield return new FileCommand("Open in Program Associated with this File ...", FileCommand.HandleOpenInApp_Click);
		}

		/// ------------------------------------------------------------------------------------
		public virtual bool IsForUnknownFileTypes
		{
			get { return false; }
		}

		/// ------------------------------------------------------------------------------------
		public virtual bool IsAudioOrVideo
		{
			get { return false; }
		}

		public virtual IEnumerable<FieldDefinition> FactoryFields
		{
			get { return new List<FieldDefinition>(); }
		}

		/// ------------------------------------------------------------------------------------
		public override string ToString()
		{
			return Name;
		}

		/// ------------------------------------------------------------------------------------
		public virtual string GetMetaFilePath(string pathToAnnotatedFile)
		{
			return pathToAnnotatedFile + Settings.Default.MetadataFileExtension;
		}

		public bool GetIsCustomFieldId(string key)
		{
			return !FactoryFields.Any(f => f.Key == key);
		}
	}

	#region PersonFileType class
	/// ----------------------------------------------------------------------------------------
	public class PersonFileType : FileType
	{
		private readonly Func<PersonBasicEditor.Factory> _personBasicEditorFactoryLazy;

		/// ------------------------------------------------------------------------------------
		/// <summary>
		///
		/// </summary>
		/// <param name="personBasicEditorFactoryLazy">This is to get us around a circular dependency
		/// error in autofac.  NB: when we move to .net 4, this can be replaced by Lazy<Func<PersonBasicEditor.Factory></param>
		/// ------------------------------------------------------------------------------------
		public PersonFileType(Func<PersonBasicEditor.Factory> personBasicEditorFactoryLazy)
			: base("Person", p => p.EndsWith(".person"))
		{
			_personBasicEditorFactoryLazy = personBasicEditorFactoryLazy;
		}

		/// ------------------------------------------------------------------------------------
		public override string GetMetaFilePath(string pathToAnnotatedFile)
		{
			return pathToAnnotatedFile; //we are our own metadata file, there is no sidecar
		}

		/// <summary>
		/// These are fields which are always available for files of this type
		/// </summary>
		public override IEnumerable<FieldDefinition> FactoryFields
		{
			get
			{
				return from key in
					new []{
							"id",
							"primaryLanguage",
							"primaryLanguageLearnedIn",
							"otherLanguage0",
							"otherLanguage1",
							"otherLanguage2",
							"otherLanguage3",
							"fathersLanguage",
							"mothersLanguage",
							"pbOtherLangFather0",
							"pbOtherLangFather1",
							"pbOtherLangFather2",
							"pbOtherLangFather3",
							"pbOtherLangMother0",
							"pbOtherLangMother3",
							"pbOtherLangMother2",
							"pbOtherLangMother1",
							"birthYear",
							"gender",
							"howToContact",
							"education",
							"primaryOccupation",
							"picture",
							"notes"
						}
				select new FieldDefinition(key, "string", new string[0]);

			}
		}

		/// ------------------------------------------------------------------------------------
		public override string FieldsGridSettingsName
		{
			get { return "PersonCustomFieldsGrid"; }
		}

		/// ------------------------------------------------------------------------------------
		protected override IEnumerable<IEditorProvider> GetNewSetOfEditorProviders(ComponentFile file)
		{
			var text = LocalizationManager.LocalizeString("PersonInfoEditor.PersonTabText", "Person");
			yield return _personBasicEditorFactoryLazy()(file, text, "Person");

			text = LocalizationManager.LocalizeString("PersonInfoEditor.NotesTabText", "Notes");
			yield return new NotesEditor(file, text, "Notes");

			//_editors.Add(new ContributorsEditor(file, "Contributors", "Contributors"));
		}

		/// ------------------------------------------------------------------------------------
		/// <param name="filePath"></param>
		public override IEnumerable<FileCommand> GetCommands(string filePath)
		{
			yield return new FileCommand("Show in File Explorer...",
										 FileCommand.HandleOpenInFileManager_Click);
		}

		/// ------------------------------------------------------------------------------------
		public override Image SmallIcon
		{
			get { return Resources.PersonFileImage; }
		}
	}

	#endregion

	#region SessionFileType class
	/// ----------------------------------------------------------------------------------------
	public class SessionFileType : FileType
	{
		private readonly Func<SessionBasicEditor.Factory> _sessionBasicEditorFactoryLazy;

		/// ------------------------------------------------------------------------------------
		/// <summary>
		///
		/// </summary>
		/// <param name="sessionBasicEditorFactoryLazy">This is to get us around a circular dependency
		/// error in autofac.  NB: when we move to .net 4, this can be replaced by Lazy<Func<SessionBasicEditor.Factory></param>
		/// ------------------------------------------------------------------------------------
		public SessionFileType(Func<SessionBasicEditor.Factory> sessionBasicEditorFactoryLazy)
			: base("Session", p => p.EndsWith(".session"))
		{
			_sessionBasicEditorFactoryLazy = sessionBasicEditorFactoryLazy;
		}

		/// ------------------------------------------------------------------------------------
		public override string FieldsGridSettingsName
		{
			get { return "SessionCustomFieldsGrid"; }
		}

		/// <summary>
		/// These are fields which are always available for files of this type
		/// </summary>
		public override IEnumerable<FieldDefinition> FactoryFields
		{
			get
			{
				return from key in
						   new[]{
								 "date",
								 "synopsis",
								 "access",
								 "location",
								 "setting",
								 "situation",
								 "eventType",
								 "participants",
								 "title",
								 "notes"
						}
					   select new FieldDefinition(key, "string", new string[0]);
			}
		}

		/// ------------------------------------------------------------------------------------
		protected override IEnumerable<IEditorProvider> GetNewSetOfEditorProviders(ComponentFile file)
		{
			var text = LocalizationManager.LocalizeString("SessionInfoEditor.SessionTabText", "Session");
			yield return _sessionBasicEditorFactoryLazy()(file, text, "Session");

			text = LocalizationManager.LocalizeString("SessionInfoEditor.NotesTabText", "Notes");
			yield return new NotesEditor(file, text, "Notes");

			//_editors.Add(new ContributorsEditor(file, "Contributors", "Contributors"));
		}

		/// ------------------------------------------------------------------------------------
		public override string GetMetaFilePath(string pathToAnnotatedFile)
		{
			return pathToAnnotatedFile; //we are our own metadata file, there is no sidecar
		}

		/// ------------------------------------------------------------------------------------
		/// <param name="filePath"></param>
		public override IEnumerable<FileCommand> GetCommands(string filePath)
		{
			yield return new FileCommand("Show in File Explorer...",
										 FileCommand.HandleOpenInFileManager_Click);
		}

		/// ------------------------------------------------------------------------------------
		public override Image SmallIcon
		{
			get { return Resources.SessionFileImage; }
		}
	}

	#endregion

	#region AudioFileType class
	/// ----------------------------------------------------------------------------------------
	public class AudioFileType : FileType
	{
		private readonly Func<AudioComponentEditor.Factory> _audioComponentEditorFactoryLazy;

		/// ------------------------------------------------------------------------------------
		public AudioFileType(Func<AudioComponentEditor.Factory> audioComponentEditorFactoryLazy)
			: base("Audio",
			p => Settings.Default.AudioFileExtensions.Cast<string>().Any(ext => p.ToLower().EndsWith(ext)))
		{
			_audioComponentEditorFactoryLazy = audioComponentEditorFactoryLazy;
		}

		/// ------------------------------------------------------------------------------------
		public override bool IsAudioOrVideo
		{
			get { return true; }
		}

		/// <summary>
		/// These are fields which are always available for files of this type
		/// </summary>
		public override IEnumerable<FieldDefinition> FactoryFields
		{
			get {return AudioFields;}
		}

		/// <summary>
		/// This is separated out so that video can reuse it.
		/// </summary>
		internal static IEnumerable<FieldDefinition> AudioFields
		{
			get
			{
				foreach (var key in new[] {"Recordist", "Device", "Microphone",})
				{
					yield return new FieldDefinition(key, "string", new string[0]);
				}

				foreach (var key in new[] {"Duration", "Channels", "Bit_Depth", "Sample_Rate"})
				{
					yield return new FieldDefinition(key, "string", new string[0])
									{
										ReadOnly = true
									};
				}
			}
		}

		/// ------------------------------------------------------------------------------------
		public override string FieldsGridSettingsName
		{
			get { return "AudioFileFieldsGrid"; }
		}

		/// ------------------------------------------------------------------------------------
		protected override IEnumerable<IEditorProvider> GetNewSetOfEditorProviders(ComponentFile file)
		{
			var text = LocalizationManager.LocalizeString("AudioFileInfoEditor.PlaybackTabText", "Audio");
			yield return new AudioVideoPlayer(file, text, "Audio");

			text = LocalizationManager.LocalizeString("AudioFileInfoEditor.PropertiesTabText", "Properties");
			yield return _audioComponentEditorFactoryLazy()(file, text, null);

			text = LocalizationManager.LocalizeString("AudioFileInfoEditor.NotesTabText", "Notes");
			yield return new NotesEditor(file, text, "Notes");

			//_editors.Add(new ContributorsEditor(file, "Contributors", "Contributors"));
		}

		/// ------------------------------------------------------------------------------------
		public override Image SmallIcon
		{
			get {return Resources.AudioFileImage;}
		}
	}

	#endregion

	#region VideoFileType class
	/// ----------------------------------------------------------------------------------------
	public class VideoFileType : FileType
	{
		private readonly Func<VideoComponentEditor.Factory> _videoComponentEditorFactoryLazy;

		/// ------------------------------------------------------------------------------------
		public VideoFileType(Func<VideoComponentEditor.Factory> videoComponentEditorFactoryLazy)
			: base("Video",
				p => Settings.Default.VideoFileExtensions.Cast<string>().Any(ext => p.ToLower().EndsWith(ext)))
		{
			_videoComponentEditorFactoryLazy = videoComponentEditorFactoryLazy;
		}

		/// ------------------------------------------------------------------------------------
		public override bool IsAudioOrVideo
		{
			get { return true; }
		}

		/// <summary>
		/// These are fields which are always available for files of this type
		/// </summary>
		public override IEnumerable<FieldDefinition> FactoryFields
		{
			get
			{
				foreach (var field in AudioFileType.AudioFields)
				{
					yield return field;
				}

				//add video only fields
				foreach (var key in new[] { "Resolution","Frame_Rate"})
				{
					yield return new FieldDefinition(key, "string", new string[0])
					{
						ReadOnly = true
					};
				}
			}
		}

		/// ------------------------------------------------------------------------------------
		public override string FieldsGridSettingsName
		{
			get { return "VideoFileFieldsGrid"; }
		}


		public override IEnumerable<FileCommand> GetCommands(string filePath)
		{
			foreach (var fileCommand in base.GetCommands(filePath))
			{
				yield return fileCommand;
			}

			yield return null; // menu separator

			if (!File.Exists(filePath.Replace(Path.GetExtension(filePath), ".mp3")))
			{
				yield return new FileCommand("Extract audio to mp3 file", ExtractMp3Audio);
			}
		}

		private void ExtractMp3Audio(string path)
		{
			if(!Palaso.Media.MediaInfo.HaveNecessaryComponents)
			{
				MessageBox.Show("SayMore could not find the proper FFmpeg on this computer. FFmpeg is required to do that conversion.");
			}
			var outputPath = path.Replace(Path.GetExtension(path), ".mp3");

			if(File.Exists(outputPath))
			{
				//todo ask the user (or don't off this in the first place)
				//File.Delete(outputPath);

				Palaso.Reporting.ErrorReport.NotifyUserOfProblem("Sorry, the file "+Path.GetFileName(outputPath)+" already exists.");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			//TODO...provide some progress
			var results = FFmpegRunner.ExtractMp3Audio(path, outputPath, new NullProgress());
			Cursor.Current = Cursors.Default;
			if(results.ExitCode !=0)
			{
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem("Something didn't work out. FFmpeg said (start reading from the end):" + Environment.NewLine + Environment.NewLine + results.StandardError);
				return;
			}

		}

		/// ------------------------------------------------------------------------------------
		protected override IEnumerable<IEditorProvider> GetNewSetOfEditorProviders(ComponentFile file)
		{
			var text = LocalizationManager.LocalizeString("VideoFileInfoEditor.PlaybackTabText", "Video");
			yield return new AudioVideoPlayer(file, text, "Video");

			text = LocalizationManager.LocalizeString("VideoFileInfoEditor.PropertiesTabText", "Properties");
			yield return _videoComponentEditorFactoryLazy()(file, text, null);

			text = LocalizationManager.LocalizeString("VideoFileInfoEditor.NotesTabText", "Notes");
			yield return new NotesEditor(file, text, "Notes");

			//_editors.Add(new ContributorsEditor(file, "Contributors", "Contributors"));

		}

		/// ------------------------------------------------------------------------------------
		public override Image SmallIcon
		{
			get { return Resources.VideoFileImage; }
		}
	}

	#endregion

	#region ImageFileType class
	/// ----------------------------------------------------------------------------------------
	public class ImageFileType : FileType
	{
		/// ------------------------------------------------------------------------------------
		public ImageFileType(Func<BasicFieldGridEditor.Factory> basicFieldGridEditorFactoryLazy)
			: base("Image",
			p => Settings.Default.ImageFileExtensions.Cast<string>().Any(ext => p.ToLower().EndsWith(ext)))
		{
			_basicFieldGridEditorFactoryLazy = basicFieldGridEditorFactoryLazy;
		}

		/// ------------------------------------------------------------------------------------
		public override string FieldsGridSettingsName
		{
			get { return "ImageFileFieldsGrid"; }
		}

		/// ------------------------------------------------------------------------------------
		protected override IEnumerable<IEditorProvider> GetNewSetOfEditorProviders(ComponentFile file)
		{
			var text = LocalizationManager.LocalizeString("ImageFileInfoEditor.ViewTabText", "Image");
			yield return new ImageViewer(file, text, "Image");

			text = LocalizationManager.LocalizeString("ImageFileInfoEditor.PropertiesTabText", "Properties");
			yield return _basicFieldGridEditorFactoryLazy()(file, text, null);

			text = LocalizationManager.LocalizeString("ImageFileInfoEditor.NotesTabText", "Notes");
			yield return new NotesEditor(file, text, "Notes");

			//_editors.Add(new ContributorsEditor(file, "Contributors", "Contributors"));
		}

		/// ------------------------------------------------------------------------------------
		public override Image SmallIcon
		{
			get { return Resources.ImageFileImage; }
		}
	}

	#endregion
}