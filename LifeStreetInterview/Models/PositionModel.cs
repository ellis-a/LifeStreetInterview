namespace LifeStreetInterview.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int SalaryBonus { get; set; }

        public PositionModel(string jobTitle, int salaryBonus)
        {
            SalaryBonus = salaryBonus;
            JobTitle = jobTitle;
        }
    }
}