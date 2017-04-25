using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExtractScreenshot
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            if (args.Length == 1)
                fileName = args[0];
            else
            {
                Console.Write("File Name:");
                fileName = Console.ReadLine();
            }
            var document = XDocument.Load(fileName);
            var listScreenshot = document.Descendants().Where(el => el.Attribute("InformativeScreenshot") != null).Attributes().Where(att => att.Name == "InformativeScreenshot").Select(at => at.Value);
            var path = fileName.Substring(0, fileName.LastIndexOf('\\'));
            var newPath = path + "\\Screenshots";
            Directory.CreateDirectory(newPath);
            foreach (var screen in listScreenshot.Distinct())
            {
                //if (File.Exists($"{newPath}\\{screen}.png") == false)                
                File.Copy($"{path}\\.screenshots\\{screen}.png", $"{newPath}\\{screen}.png", true);
            }
        }
    }
}
