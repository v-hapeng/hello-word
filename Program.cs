using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace wenjian
{
    class Program
    {
        public class Test
        {
            public string modelname { get; set; }
            public string query { get; set; }
            public string url { get; set; }
            public string caption { get; set; }
            public string judgement { get; set; }

  

        }




        public static void Main()
        {
            List<Test> lines= BuildList();
            var line = from c in lines
                       group c by c.modelname;

            foreach (var t in line)
            {
                Console.WriteLine(t.Key);
                for (int m = 0; m < (t.Key).Count(); m++)
                {
                    int j = 0;
                    int i = 0;
                    foreach (Test customer in t)
                    {
                        Console.WriteLine("{0}", customer.judgement);
                        if (customer.judgement == "good")
                        {
                            i++;
                        }
                        j++;
                    }
                    double x = (double)i / j;
                    Console.WriteLine(t.Key + "组的百分比为" + x);
                }
            }




                  
            Console.ReadKey();
        }
        public static List<Test> BuildList()
        {
            List<Test> list = new List<Test>();
            StreamReader sr = new StreamReader(@"D:\1.tsv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var columns = line.Split('\t');

                list.Add(new Test()
                {
                    modelname = columns[0],
                    query = columns[1],
                    url= columns[2],
                    caption= columns[3],
                    judgement = columns[4]
                });
            }
            return list;
        }


    }
}

