using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace General.Script {
	public class SharpScript {
		public string Code;
		public IScript script;
		private Assembly asm;

		public SharpScript() {
		}

		public object Invoke(string function, params object[] parameters) {
			if (script != null) {
				foreach (Type type in asm.GetExportedTypes()) {
					foreach (Type iface in type.GetInterfaces()) {
						if (iface == typeof (IScript)) {
							try {
								MethodInfo method = type.GetMethod(function);
								if (method != null) {
									return method.Invoke(script, parameters);
								} else {
									Console.WriteLine("Method '" + function + "' is non-existant");
									return null;
								}
							} catch (Exception e) {
								Console.WriteLine("Error trying to invoke function '" + function + "'");
								return null;
							}
						}
					}
				}
			}
			return null;
		}

		public void CompileCode(string code, params object[] parameters) {
			CSharpCodeProvider compiler = new CSharpCodeProvider();

			CompilerParameters options = new CompilerParameters();
			options.GenerateExecutable = false;
			options.GenerateInMemory = true;
			options.TreatWarningsAsErrors = false;

			options.ReferencedAssemblies.Add("General.dll");
			options.ReferencedAssemblies.Add("General.Graphics.dll");
			options.ReferencedAssemblies.Add("GameEngine.Data.dll");
			options.ReferencedAssemblies.Add("MapEditor.Data.dll");
			options.ReferencedAssemblies.Add("System.dll");
			//options.ReferencedAssemblies.Add("Microsoft.Xna.Framework.dll");
			//options.ReferencedAssemblies.Add("Microsoft.Xna.Framework.Graphics.dll");
			
			CompilerResults result = compiler.CompileAssemblyFromSource(options, code);

			if (result.Errors.HasErrors) {
				Console.ForegroundColor = ConsoleColor.Red;
				int count = 0;
				foreach (CompilerError error in result.Errors) {
					if (!error.IsWarning) count++;
				}
				Console.WriteLine("Could not compile SharpScript, " + count + " Errors found:");
				int i = 0;
				foreach (CompilerError error in result.Errors) {
					if (!error.IsWarning)
						Console.WriteLine(++i + ". " + error.ErrorText + " at line " + error.Line);
				}
				Console.ResetColor();
				return;
			}

			if (result.Errors.HasWarnings) {
			}

			asm = result.CompiledAssembly;

			if (asm != null) {
				foreach (Type type in asm.GetExportedTypes()) {
					foreach (Type iface in type.GetInterfaces()) {
						ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);

						if (constructor != null && constructor.IsPublic) {
							this.script = constructor.Invoke(parameters) as IScript;
						}
					}
				}
			}
		}
	}
}