using System;

namespace HelloWorld
{
    class helloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String name;
            Console.WriteLine("What is your name?:");
            name = Console.ReadLine(); // This is how I can get user input
            Console.WriteLine(String.Format("Your name is {0}! That\'s really cool!!",name)); // C# is kinda wierd with the String.Format
            if (name.Equals("Matt"))
            {
                Console.WriteLine("Hey, you have the same name as me!!");
            } else
            {
                Console.WriteLine("Oh, our names are differnt lol");
            }
            int[] ints = {10,20,30};
            for(int j  = 0; j < ints.Length; j++)
            {
                Console.WriteLine(ints[j]);
            }
            bool isCool = false;
            int i = 0;
            while(i < 10)
            {
                Console.WriteLine(Convert.ToString(i) + " is the current value of i");
                i++;
            }
            isCool = !isCool;
            Console.WriteLine(isCool);
        }
    }
}