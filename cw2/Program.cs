using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace cw2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var sourcePath = "data.csv";
            var sourcePath = @"C:\Users\Wojtek\Desktop\cw2\dane\dane.csv";
            var desPath = "result.xml";
            var type = "xml";
            if (args.Length == 3)
            {
                sourcePath = args[0];
                desPath = args[1];
                type = args[2];
            }

            //var path = @"C:\Users\s18637\Desktop\dane.csv";
            if(Uri.IsWellFormedUriString(sourcePath, UriKind.RelativeOrAbsolute) && Uri.IsWellFormedUriString(desPath, UriKind.RelativeOrAbsolute))
            {
                throw new ArgumentException("Podana sciezka jest nie prawidlowa");
            }

            if (File.Exists(sourcePath))
            {
                throw new FileNotFoundException("Podany plik nie istnieje");
            }

            var lines = File.ReadLines(sourcePath);
            ICollection<string> log = new List<string>();
            var hash = new HashSet<Student>(new OwnComaparer());
            foreach (var line in lines)
            {
                var word = line.Split(",");
                if (word.Length == 9)
                {
                    Student student = new Student(word[0], word[1], word[2], word[3], word[4], DateTime.Parse(word[5]), word[6], word[7], word[8]);
                    var check = hash.Add(student);
                    if (!check)
                    {
                        log.Add(line);
                    }
                    
                }
                else
                {
                    log.Add(line);
                }
            }
            if (type.Equals("xml"))
            {
                FileStream writer = new FileStream(desPath, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
                serializer.Serialize(writer, hash);
                
            }
            if (type.Equals("json"))
            {
                string jsonString = JsonConvert.SerializeObject(hash);
                File.WriteAllText(desPath, jsonString);
            }
            string alllog = "";
            foreach (var line in log)
            {
                    alllog += line;
            }
            Console.WriteLine(alllog);
            File.WriteAllText(@"log.txt", alllog);
        }
    }
}
