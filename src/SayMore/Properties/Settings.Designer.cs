//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SayMore.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection MRUList {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["MRUList"]));
            }
            set {
                this["MRUList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int LocalizationDlgSplitterPos {
            get {
                return ((int)(this["LocalizationDlgSplitterPos"]));
            }
            set {
                this["LocalizationDlgSplitterPos"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0, 0, -1")]
        public global::System.Drawing.Rectangle LocalizationDlgBounds {
            get {
                return ((global::System.Drawing.Rectangle)(this["LocalizationDlgBounds"]));
            }
            set {
                this["LocalizationDlgBounds"] = value;
            }
        }
        
        /// <summary>
        /// Character used to replace invalid path characters in a person&apos;s name when building a safe name to store in file system.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Character used to replace invalid path characters in a person\'s name when buildin" +
            "g a safe name to store in file system.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("_")]
        public char SafeNameReplacementChar {
            get {
                return ((char)(this["SafeNameReplacementChar"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("207, 240, 159")]
        public global::System.Drawing.Color DataEntryPanelColorBegin {
            get {
                return ((global::System.Drawing.Color)(this["DataEntryPanelColorBegin"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("169, 219, 168")]
        public global::System.Drawing.Color DataEntryPanelColorEnd {
            get {
                return ((global::System.Drawing.Color)(this["DataEntryPanelColorEnd"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("148, 195, 151")]
        public global::System.Drawing.Color DataEntryPanelColorBorder {
            get {
                return ((global::System.Drawing.Color)(this["DataEntryPanelColorBorder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("196, 209, 227")]
        public global::System.Drawing.Color BarColorBegin {
            get {
                return ((global::System.Drawing.Color)(this["BarColorBegin"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("124, 153, 193")]
        public global::System.Drawing.Color BarColorEnd {
            get {
                return ((global::System.Drawing.Color)(this["BarColorEnd"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("83, 110, 145")]
        public global::System.Drawing.Color BarColorBorder {
            get {
                return ((global::System.Drawing.Color)(this["BarColorBorder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int GapBetweenMultimediaObjects {
            get {
                return ((int)(this["GapBetweenMultimediaObjects"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("200")]
        public int DefaultHeightOfVideoControl {
            get {
                return ((int)(this["DefaultHeightOfVideoControl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("65")]
        public int DefaultHeightOfAudioControl {
            get {
                return ((int)(this["DefaultHeightOfAudioControl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("200")]
        public int DefaultHeightOfImageControl {
            get {
                return ((int)(this["DefaultHeightOfImageControl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>.mp3</string>
  <string>.wav</string>
  <string>.wma</string>
  <string>.acc</string>
  <string>.ogg</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection AudioFileExtensions {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["AudioFileExtensions"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>.wmv</string>
  <string>.avi</string>
  <string>.mpg</string>
  <string>.mpeg</string>
  <string>.mpa</string>
  <string>.asf</string>
  <string>.mov</string>
  <string>.mp4</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection VideoFileExtensions {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["VideoFileExtensions"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>.jpg</string>
  <string>.jpeg</string>
  <string>.gif</string>
  <string>.tif</string>
  <string>.png</string>
  <string>.bmp</string>
  <string>.dib</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection ImageFileExtensions {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ImageFileExtensions"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RedrawAsMainWndResizes {
            get {
                return ((bool)(this["RedrawAsMainWndResizes"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.FormSettings NewSessionsFromFilesDlg {
            get {
                return ((global::SilUtils.FormSettings)(this["NewSessionsFromFilesDlg"]));
            }
            set {
                this["NewSessionsFromFilesDlg"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings NewSessionsFromFilesDlgComponentGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["NewSessionsFromFilesDlgComponentGrid"]));
            }
            set {
                this["NewSessionsFromFilesDlgComponentGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string NewSessionsFromFilesLastFolder {
            get {
                return ((string)(this["NewSessionsFromFilesLastFolder"]));
            }
            set {
                this["NewSessionsFromFilesLastFolder"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("www.sil.org")]
        public string SilWebSite {
            get {
                return ((string)(this["SilWebSite"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://saymore.palaso.org/")]
        public string ProgramsWebSite {
            get {
                return ((string)(this["ProgramsWebSite"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int PersonScreenElementListSpiltterPos {
            get {
                return ((int)(this["PersonScreenElementListSpiltterPos"]));
            }
            set {
                this["PersonScreenElementListSpiltterPos"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int PersonScreenComponentsSplitterPos {
            get {
                return ((int)(this["PersonScreenComponentsSplitterPos"]));
            }
            set {
                this["PersonScreenComponentsSplitterPos"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int SessionScreenElementsListSplitterPos {
            get {
                return ((int)(this["SessionScreenElementsListSplitterPos"]));
            }
            set {
                this["SessionScreenElementsListSplitterPos"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int SessionScreenComponentsSplitterPos {
            get {
                return ((int)(this["SessionScreenComponentsSplitterPos"]));
            }
            set {
                this["SessionScreenComponentsSplitterPos"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.FormSettings WelcomeDialog {
            get {
                return ((global::SilUtils.FormSettings)(this["WelcomeDialog"]));
            }
            set {
                this["WelcomeDialog"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.FormSettings ProjectWindow {
            get {
                return ((global::SilUtils.FormSettings)(this["ProjectWindow"]));
            }
            set {
                this["ProjectWindow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings SessionScreenComponentGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["SessionScreenComponentGrid"]));
            }
            set {
                this["SessionScreenComponentGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings PersonScreenComponentGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["PersonScreenComponentGrid"]));
            }
            set {
                this["PersonScreenComponentGrid"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool PauseMediaPlayerWhenTabLoosesFocus {
            get {
                return ((bool)(this["PauseMediaPlayerWhenTabLoosesFocus"]));
            }
        }
        
        /// <summary>
        /// These are zoom percentages used when clicking on an image in an image viewer. For each click, the zoom is increased to the next percentage value. When the max value is reached, the zoom percentage changes to the lowest value, etc.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("These are zoom percentages used when clicking on an image in an image viewer. For" +
            " each click, the zoom is increased to the next percentage value. When the max va" +
            "lue is reached, the zoom percentage changes to the lowest value, etc.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25, 50, 75,100, 125, 150, 175, 200, 225, 250, 275, 300")]
        public string ImageViewerClickImageZoomPercentages {
            get {
                return ((string)(this["ImageViewerClickImageZoomPercentages"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>.session</string>
  <string>.person</string>
  <string>.meta</string>
  <string>thumbs.db</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection ComponentFileEndingsNotAllowed {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ComponentFileEndingsNotAllowed"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".meta")]
        public string MetadataFileExtension {
            get {
                return ((string)(this["MetadataFileExtension"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".session")]
        public string SessionFileExtension {
            get {
                return ((string)(this["SessionFileExtension"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".person")]
        public string PersonFileExtension {
            get {
                return ((string)(this["PersonFileExtension"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".sprj")]
        public string ProjectFileExtension {
            get {
                return ((string)(this["ProjectFileExtension"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string LastFolderForComponentFileAdd {
            get {
                return ((string)(this["LastFolderForComponentFileAdd"]));
            }
            set {
                this["LastFolderForComponentFileAdd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-1")]
        public int AudioVideoPlayerVolume {
            get {
                return ((int)(this["AudioVideoPlayerVolume"]));
            }
            set {
                this["AudioVideoPlayerVolume"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoPlayMediaPlayerWhenSelectingMediaFile {
            get {
                return ((bool)(this["AutoPlayMediaPlayerWhenSelectingMediaFile"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CustomSessionFileFields {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CustomSessionFileFields"]));
            }
            set {
                this["CustomSessionFileFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CustomPersonFileFields {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CustomPersonFileFields"]));
            }
            set {
                this["CustomPersonFileFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CustomImageFileFields {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CustomImageFileFields"]));
            }
            set {
                this["CustomImageFileFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CustomAudioFileFields {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CustomAudioFileFields"]));
            }
            set {
                this["CustomAudioFileFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CustomVideoFileFields {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CustomVideoFileFields"]));
            }
            set {
                this["CustomVideoFileFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CustomUnknownFileFields {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CustomUnknownFileFields"]));
            }
            set {
                this["CustomUnknownFileFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings SessionCustomFieldsGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["SessionCustomFieldsGrid"]));
            }
            set {
                this["SessionCustomFieldsGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings PersonCustomFieldsGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["PersonCustomFieldsGrid"]));
            }
            set {
                this["PersonCustomFieldsGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings AudioFileFieldsGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["AudioFileFieldsGrid"]));
            }
            set {
                this["AudioFileFieldsGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings VideoFileFieldsGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["VideoFileFieldsGrid"]));
            }
            set {
                this["VideoFileFieldsGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings ImageFileFieldsGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["ImageFileFieldsGrid"]));
            }
            set {
                this["ImageFileFieldsGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(SilUtils.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::SilUtils.GridSettings UnknownFileFieldsGrid {
            get {
                return ((global::SilUtils.GridSettings)(this["UnknownFileFieldsGrid"]));
            }
            set {
                this["UnknownFileFieldsGrid"] = value;
            }
        }
    }
}
