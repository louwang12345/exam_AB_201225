using System;
using System.Collections.Generic;
using System.IO;


namespace quizze3
{  
   public class Data
   {
        public string name { get;set; }
        public string date { get;set ;}
        public string content { get;set;}
         public List<string> csv { get;set;}
   }

    class Program
    {   
         
        static void Main(string[] args)
        { 
            List<Data> lineRecords=new List<Data>();
            string fileName="test.txt";
            bool startCsv=false;
            int csvCount=0;
            int lineCount=0;
            string currentDir= Directory.GetCurrentDirectory();
            string[] paths={currentDir,fileName};
            string filePath=Path.Combine(paths);
            string[] lines =new string[0];

            if(File.Exists(filePath)){
                lines = System.IO.File.ReadAllLines(filePath);
            }
            else
            {
                Console.WriteLine(filePath+"file not exist!!!!");
                return;
            }
            
            Data newData=null;
            foreach (string line in lines)
            {
                 lineCount++;
                if (line[0]=='#')
                {
                    continue;
                }
                else if (line==string.Empty)
                {
                    continue;
                }

                if (line.Contains("Name") )
				{
                    if (newData!=null){
                        //normal data add here
                        lineRecords.Add(newData);
                    }
                    newData = null;
                    startCsv=false;
                    csvCount=0;
                    newData =new Data();
                    newData.csv=new List<string>();
                    string[] split = line.Split(new string[] {":"}, StringSplitOptions.RemoveEmptyEntries);
                    newData.name="Name: "+(split[1].Trim());
					
				}
                else if (line.Contains("Date") )
                {  
                    if (newData!=null){
                        string[] split = line.Split(new string[] {":"}, StringSplitOptions.RemoveEmptyEntries);
                        newData.date="Date: "+(split[1].Trim());
                    }
                }

                else if (line.Contains("Content") )
                {  
                    if (newData!=null){
                        string[] split = line.Split(new string[] {":"}, StringSplitOptions.RemoveEmptyEntries);
                        newData.content="Content: "+(split[1].Trim())+"\n"+"CsvData:";
                        startCsv=true;
                        continue;
                    }
                }
                if (startCsv){
                    newData.csv.Add(line);
                    csvCount++;
                }
               
                //last data need Add 
                if(lineCount==lines.Length)
                {
                     if (newData!=null){
                        lineRecords.Add(newData);
                    }
                } 
            }
            // print Data
            Console.WriteLine("---------------------------------------");
            foreach(Data list in lineRecords){
                Console.WriteLine(list.name);
                Console.WriteLine(list.date);
                Console.WriteLine(list.content);
                foreach( string csv in list.csv){
                    Console.WriteLine(csv);
                }
            }
            Console.WriteLine("---------------------------------------");
        }

    }


}
