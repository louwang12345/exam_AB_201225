using System;


namespace quizze1
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] myArray= new int[] { 10, 20, 30, 40, 50, 60, 70 };
           int[] newArray= shuffle(myArray);
           show(newArray);
        
        }
        static int[] shuffle(int[] myArray){
            Random rnd = new Random();
            for (int i = myArray.Length-1; i>=0 ; i-- )
            {
                //get random index
                int randomIndex = rnd.Next(0, i);
                int itematIndex=myArray[randomIndex];
                myArray[randomIndex] = myArray[i];
                myArray[i] = itematIndex;
            }
            return myArray;
        }
        static void show(int[] newArray){
            Console.WriteLine("---------------------");
            foreach(int item in newArray)
            {
                Console.Write(item+" ,");
            }
            Console.WriteLine("\n"+"---------------------");
        }
    }
   
}
