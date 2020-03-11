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

            var path = @"C:\Users\s18637\Desktop\dane.csv";
            var lines = File.ReadLines(path);
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
            FileStream writer = new FileStream(@"Z:\APBD\cw2\cw2\data\data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, hash);
            writer = new FileStream(@"Z:\APBD\cw2\cw2\data\log.txt", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(writer);
            string alllog="";
            foreach (var line in log) {
                alllog += line;
            }
            File.WriteAllText(@"Z:\APBD\cw2\cw2\data\log.txt", alllog);
        }
    }
}
