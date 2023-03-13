using System;
namespace firstSpace { // This makes it so I could have a class of the same name in a different namespace
    class Person 
    {
        private int age;
        private String name;

        public Person(int age = 0, String name = "")
        {
            this.age = age;
            this.name = name;
        }

        public int getAge()
        {
            return age;
        }

        public String getName()
        {
            return name;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public void setName(String name)
        {
            this.name = name;
        }
    }

    class main
    {
        static void Main(string[] args)
        {
            int age; string name;
            Console.WriteLine("How old are you?: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your name?: ");
            name = Console.ReadLine();
            Person p1 = new Person(age, name);
            Console.WriteLine(String.Format("Hello there {0}! You are {1} years old!!", p1.getName(), p1.getAge()));
        }
    }
}

