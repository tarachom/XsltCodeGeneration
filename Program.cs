using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using System.IO;
using System.Reflection;

namespace XsltCodeGeneration
{
	class Program
	{
		static void Main(string[] args)
		{
			string DirectoryParent = GetDirectoryParent();

			XslCompiledTransform xsltCodeGenerator = new XslCompiledTransform();
			xsltCodeGenerator.Load(DirectoryParent + "Fields.xslt");

			XsltArgumentList xsltArg = new XsltArgumentList();
			xsltArg.AddParam("datetime", "", DateTime.Now.ToString("dd.MM.yyyy"));

			if (File.Exists(DirectoryParent + "Fields.cs"))
				File.WriteAllText(DirectoryParent + "Fields.cs", String.Empty);

			xsltCodeGenerator.Transform(DirectoryParent + "Fields.xml", xsltArg, File.OpenWrite(DirectoryParent + "Fields.cs"));
		}

		/// <summary>
		/// Повертає шлях до папки з даними
		/// </summary>
		/// <returns></returns>
		static string GetDirectoryParent()
		{
			string DirectoryAssembly = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
			string DirectoryParent = Directory.GetParent(DirectoryAssembly).FullName;

			return DirectoryParent + @"\";
		}
	}
}
