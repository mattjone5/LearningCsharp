using System;

namespace main
{
    class Employee
    {
        private int salary;
        private string employeeID;
        private int employeeType;

        public Employee(int salary = 0, string employeeID = "", int employeeType = 0)
        {
            this.salary = salary;
            this.employeeID = employeeID;
            this.employeeType = employeeType;
        }

        public void setSalary(int salary)
        {
            this.salary = salary;
        }

        public void setEmployeeID(string employeeID)
        {
            this.employeeID = employeeID;
        }

        public void setEmployeeType(int employeeType)
        {
            this.employeeType = employeeType;
        }

        public int getSalary()
        {
            return salary;
        }

        public string getEmployeeID()
        {
            return employeeID;
        }

        public int getEmployeeType()
        {
            return employeeType;
        }

        public virtual int getPay()
        {
            return 0;
        }
    }

    class WorkerEmployee : Employee
    {
        public WorkerEmployee(int salary = 0, string employeeID = "", int employeeType = 1) : base(salary, employeeID, employeeType) { }

        public override int getPay()
        {
            return (getSalary() - 1200) / 12; // This is the takeaway from their paycheck
        }
    }

    class ManagerEmployee : Employee
    {
        public ManagerEmployee(int salary = 0, string employeeID = "", int employeeType = 1) : base(salary, employeeID, employeeType) { }

        public override int getPay()
        {
            return Convert.ToInt32((getSalary() + (getSalary() * 0.2)) / 12);
        }
    }

    class MainClass
    {

        public static List<string> getDataFromFile(string employeeID)
        {
            List<string> data = new List<string>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines("input.txt");
                for(int i = 0; i < lines.Length; i++)
                {
                    string curLine = lines[i];
                    string curID = curLine.Substring(0, 8);
                    if (curID.Equals(employeeID)){
                        data.Add(curID);
                        curLine = curLine.Remove(0, 9);
                        int commaIndex = curLine.IndexOf(",");
                        string salary = curLine.Substring(0, commaIndex);
                        curLine = curLine.Remove(0, commaIndex+1);
                        data.Add(salary); data.Add(curLine);
                        break;
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("ERROR!!!");
            }

            return data;
        }

        static void saveFile(List<Employee> employees)
        {
            try
            {
                string whatTosave = "";
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        sw.WriteLine(String.Format("{0} earns ${1} per pay period.", employees[i].getEmployeeID(), employees[i].getPay()));
                    }
                }
                Console.WriteLine("A file named output.txt was created with pay information.");
            } catch (Exception e)
            {
                Console.WriteLine("ERROR!!!");
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int sizeToMake;
            Console.WriteLine("How many employees do you want to add?: ");
            sizeToMake = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < sizeToMake; i++)
            {
                Console.WriteLine(String.Format("Please enter the employee for employee #{0}", i + 1));
                string id = Console.ReadLine();
                List<string> data = getDataFromFile(id);
                while(data.Count == 0)
                {
                    Console.WriteLine("Error, that employee was not found. Please try again");
                    Console.WriteLine(String.Format("Please enter the employee for employee #{0}", i + 1));
                    id = Console.ReadLine();
                    data = getDataFromFile(id);
                }
                Console.WriteLine(String.Format("Please enter the salary for employee #{0}", i + 1));
                string salary = Console.ReadLine();
                while (!data[1].Equals(salary))
                {
                    Console.WriteLine("Error, that employee salary was not correct. Please try again");
                    Console.WriteLine(String.Format("Please enter the salary for employee #{0}", i + 1));
                    salary = Console.ReadLine();
                }
                Console.WriteLine(String.Format("Please enter the employee type for employee #{0}\n(1 for worker, 2 for manager)", i + 1));
                string type = Console.ReadLine();
                while (!data[2].Equals(type))
                {
                    Console.WriteLine("Error, that employee type was not correct. Please try again");
                    Console.WriteLine(String.Format("Please enter the employee type for employee #{0}\n(1 for worker, 2 for manager)", i + 1));
                    type = Console.ReadLine();
                }
                if (type.Equals("1"))
                {
                    employees.Add(new WorkerEmployee(Convert.ToInt32(salary), id , 1));
                }
                else
                {
                    employees.Add(new ManagerEmployee(Convert.ToInt32(salary), id, 2));
                }
            }
            saveFile(employees);

        }
    }

}