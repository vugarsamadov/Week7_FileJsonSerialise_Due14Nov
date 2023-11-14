using Week7_FileJsonSerialise_Due14Nov;
using Week7_FileJsonSerialise_Due14Nov.Interfaces;

var DataFolderPath = "C:/Users/vuqar/Desktop/Data";


Directory.CreateDirectory(DataFolderPath);
var filepath = Path.Combine(DataFolderPath, "data.json");
if(!File.Exists(filepath))
    using (File.Create(filepath)) { }


ICustomCollectionFileBasedSource<Student> fileSource = new JsonFileSource<Student>(filepath);
StudentCollection studentCollection = new(fileSource);

var student1 = new Student("Vugar","Surname","AZ001");
var student2 = new Student("Ahmad","Ahmadov","AZ002");
var student3 = new Student("Bill","Clinton","US004");

Console.ReadKey();
await studentCollection.AddAsync(student1);

Console.ReadKey();
await studentCollection.AddAsync(student2);
await studentCollection.AddAsync(student3);

Console.ReadKey();
await studentCollection.RemoveAsync(student1);

Console.ReadKey();
await studentCollection.SetAsync(0, new("Saddam", "Huseyin", "IRQ001"));

Console.ReadKey();
await studentCollection.UpdateStudentByCode("US004", new("Bill", "Huseyin", "USQ005"));

