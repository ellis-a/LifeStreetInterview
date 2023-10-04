namespace LifeStreetInterview.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public EmployeeModel()
        {
            
        }

        public Employee ToDbObject()
        {
            return new Employee 
            {
                Id = Id,
                Name = Name,
                Salary = Salary,
                Position = Position
            };
        }

        public EmployeeModel(string name, int salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
        }
    }
}