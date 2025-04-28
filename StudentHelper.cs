using System.Security.Cryptography;

namespace MenuProgram;

public class StudentHelper
{
    public string FirstName { get; set; } // ad
    public string LastName { get; set; } // soyad
    public DateOnly BirthDate { get; set; } // yaş
    public string Gender { get; set; } 
    public string StudentId { get; set; }
    public string Tckn { get; set; }
    public string Gpa { get; set; }

    public int GetAge()
    {
        return CalculateAge();
    }

    private int CalculateAge()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - BirthDate.Year;
        if (today < BirthDate.AddYears(age))
        {
            age--;
        }

        return age;
    }

    public static void ListStudents(List<StudentHelper>? students)
    {
        Console.Clear();
        Console.WriteLine("TÜM ÖĞRENCİLER \n");
        if (students == null || students.Count == 0)
        {
            Console.WriteLine("Liste boş. Lütfen öğrenci eklemek için menüden Ekle seçiniz. ");
        }
        for (int i = 0; i < students.Count; i++)
        {
            var student = students[i];
            Console.WriteLine($"[{i + 1}]{student.StudentId} - {student.FirstName} {student.LastName} - {student.Tckn}- {student.GetAge()} - {student.Gender} Not Ortalaması : {student.Gpa} ");
        }
        
    }
}