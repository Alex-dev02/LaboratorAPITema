namespace DataLayer.Entities;

public class Student : User
{
    public List<Grade> Grades { get; set; }
}

