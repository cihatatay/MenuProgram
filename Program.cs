
using MenuProgram;

var students = new List<StudentHelper>{};

while (true)
{
    Console.Clear();
    Console.WriteLine("Öğrenci Yönetim Sistemi\n".ToUpper());
    var inputSelection = Helper.AskOption("Yapmak istediğin işlemi seç", ["Listele", "Ekle", "Sil", "Güncelle", "Çıkış"]);

    if (inputSelection == 1)
    {
        Console.Clear();
        StudentHelper.ListStudents(students);
    } 
    else if (inputSelection == 2)
    {
        Console.Clear();
        Console.WriteLine("Öğrenci Ekleme Ekranı\n".ToUpper());
        var me = new StudentHelper
        {
            FirstName = Helper.Ask("İsim"),
            LastName = Helper.Ask("Soyisim"),
            BirthDate =DateOnly.Parse(Helper.Ask("Doğum Tarihi(gg/aa/yyyy)")) ,
            Gender = Helper.Ask("Cinsiyet"),
            Tckn = Helper.Ask("TC kimlik no"),
            StudentId = Helper.Ask("Öğrenci No"),
            Gpa = Helper.Ask("Not Ortalaması")
        };
        students.Add(me);
    }
    else if (inputSelection == 3)
    {
        Console.Clear();
        if (students.Count == 0 || students == null)
        {
            Console.WriteLine("Listede öğrenci bulunmamaktadır. ");
        }
        else
        {
            Console.WriteLine("Öğrenci Silme Ekranı\n".ToUpper());
            StudentHelper.ListStudents(students);
            var inputDelete = int.Parse(Helper.Ask("\nSilmek istediğiniz öğrencinin numarasını giriniz ")) ;
            var studentDelete = students[inputDelete];
            students.Remove(studentDelete);
        }
        
    }
    else if (inputSelection == 4)
    {
        Console.Clear();
        Console.WriteLine("Öğrenci Güncelleme Ekranı\n".ToUpper());
        StudentHelper.ListStudents(students);
        
        var inputUpdate =int.Parse(Helper.Ask("\nGüncellemek istediğiniz öğrencinin numarasını giriniz")) ;
        var student = students[inputUpdate - 1];
        // İsim Güncellemesi
        var newName = Helper.Ask("\nİsim");
        if (!string.IsNullOrEmpty(newName)) student.FirstName = newName;
        // Soyisim Güncellemesi   
        var newLastName = Helper.Ask("Soyisim");
        if (!string.IsNullOrEmpty(newLastName)) student.LastName = newLastName;
        // Doğum Günü Güncellemesi    
        var newBirthDate = Helper.Ask("Doğum Tarihi(gg/aa/yyyy)");
        if (!string.IsNullOrEmpty(newBirthDate)) student.BirthDate = DateOnly.Parse(newBirthDate);
        // Cinsiyet Güncellemesi    
        var newGender = Helper.Ask("Cinsiyet");
        if (!string.IsNullOrEmpty(newGender))  student.Gender = newGender;
        // TC Kimlik no Güncellemesi
        var newTckn = Helper.Ask("TC Kimlik No");
        if (!string.IsNullOrEmpty(newTckn))  student.Tckn = newTckn;
        // Öğrenci Numarası Güncellemesi
        var newStudentId = Helper.Ask("Öğrenci Numarası");
        if (!string.IsNullOrEmpty(newStudentId))  student.StudentId = newStudentId;
        // Not Ortalaması Güncellemesi
        var newGpa = Helper.Ask("Not Ortalaması");
        if (!string.IsNullOrEmpty(newGpa))  student.Gpa = newGpa;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Hoşçakalın...");
        Thread.Sleep(1000);
        break;
    }
    
    Console.WriteLine("\nMenüye dönmek için bir tuşa basın.");
    Console.ReadKey(true);
}
