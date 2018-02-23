using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime;
//using RazorEngine.Templating;
using System.IO;
using Microsoft.AspNetCore.Razor.Language;
using System.Reflection;
using RazorLight;

namespace VTutor.Email
{
    public static class EmailTemplateFactory
    {
		private static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		public static async Task<string> BasicTemplate<T>(T model, string templatePath)
        {
			IRazorLightEngine engine = new RazorLightEngineBuilder()
				.UseMemoryCachingProvider()
				.Build();//EngineFactory.CreatePhysical(AssemblyDirectory + "/EmailTemplates/");

			string templateText = File.ReadAllText(templatePath);
			string emailBody = await engine.CompileRenderAsync(templatePath, templateText, model);
			//var emailBody = engine.Parse(File.ReadAllText(templatePath), model, typeof(T), null);

            return emailBody;
                  
        }

    }
}
