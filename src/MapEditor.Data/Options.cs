using System;
using System.IO;
using System.Windows.Forms;
using General.Common;
using General.IniParser;
using General.IniParser.Model;

namespace MapEditor.Data {
	public class Options {
		public static Options Instance {
			get { return Static<Options>.Value; }
		}

		private FileIniDataParser parser;
		private IniData iniData;

		public const int IniVersion = 1;
		private string iniLoc;

		public string DefaultProject {
			get {
				return iniData["MapEditor"]["DefaultProject"];
			}
			set {
				iniData["MapEditor"]["DefaultProject"] = value;
				Save();
			}
		}

		public bool Grid {
			get {
				return Boolean.Parse(iniData["MapEditor"]["GridEnabled"]);
			}
			set {
				iniData["MapEditor"]["GridEnabled"] = value.ToString().ToLower();
				Save();
			}
		}

		public float GridOpacity {
			get {
				return Single.Parse(iniData["MapEditor"]["GridOpacity"]);
			}
			set {
				iniData["MapEditor"]["GridOpacity"] = value.ToString();
				Save();
			}
		}

		public bool LogicCorrectSameType {
			get {
				return Boolean.Parse(iniData["MapEditor"]["CorrectSameType"]);
			}
			set {
				iniData["MapEditor"]["CorrectSameType"] = value.ToString().ToLower();
			}
		}

		public bool LogicCorrectOtherType {
			get {
				return Boolean.Parse(iniData["MapEditor"]["CorrectOtherType"]);
			}
			set {
				iniData["MapEditor"]["CorrectOtherType"] = value.ToString().ToLower();
				Save();
			}
		}

		public IniData DefaultConfig {
			get {
				IniData data = new IniData();
				data.Sections.AddSection("General");
				data["General"].AddKey("Version", IniVersion.ToString());
				data.Sections.AddSection("MapEditor");
				data["MapEditor"].AddKey("DefaultProject", DefaultProject);
				data["MapEditor"].AddKey("GridEnabled", Grid.ToString().ToLower());
				data["MapEditor"].AddKey("GridOpacity", GridOpacity.ToString());
				data["MapEditor"].AddKey("CorrectSameType", LogicCorrectSameType.ToString().ToLower());
				data["MapEditor"].AddKey("CorrectOtherType", LogicCorrectOtherType.ToString().ToLower());
				return data;
			}
		}

		private bool Exists {
			get { return File.Exists(iniLoc); }
		}

		public void TryDelete() {
			if (Exists) File.Delete(iniLoc);
		}

		public void Save() {
			TryDelete();
			parser.SaveFile(iniLoc, iniData);
		}

		public void Load() {
			iniLoc = Application.StartupPath + @"\settings.ini";
			parser = new FileIniDataParser();
			if (Exists) {
				iniData = parser.ReadFile(iniLoc);
				if (Int32.Parse(iniData["General"]["Version"]) != IniVersion) {
					TryDelete();
					this.iniData = DefaultConfig;
					Save();
				}
			} else {
				this.iniData = DefaultConfig;
				Save();
			}
		}
	}
}