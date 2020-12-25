using System;

namespace quizze2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList llist = new LinkedList(); 
            //Input:
            int[] MyArray=new int[] {3,-1,1,4,2,6,8};
            foreach(int arr in MyArray){
                llist.append(arr); 
            }
            //print count
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Count of the list is :" + llist.getCount()); 
            Console.WriteLine("-----------------------------------");
        }
         
    }
     public class Node 
    { 
        public int data; 
        public int nextIndex;
        public int nodeIndex;
        public Node next; 
        public Node(int d,int index)  
        {  
            data = d; next = null; 
            nodeIndex=index;
            nextIndex=-1;

        } 
    }    
    public class LinkedList 
    { 
        Node head; 
        static int count=0;
        public void append(int newData) 
        { 
            Node newNode = new Node(newData,count); 
            count++;
            if(head==null){
                head = newNode;
            }
            else
            {
                Node tail = head;
                while (tail.next != null) {
                    tail = tail.next;
                }
                tail.next = newNode;
                tail.nextIndex=newNode.nodeIndex;
            }
            
        } 

        public int getCount() 
        { 
            Node temp = head; 
            int count = 1; 
            while (temp.nextIndex !=-1) 
            { 
                if(temp.nextIndex<-1){
                   Console.WriteLine("Error:temp.nextIndex Error= "+temp.nextIndex);  
                }
                count++; 
                temp = temp.next; 
            } 
            return count; 
        } 
    }
}
