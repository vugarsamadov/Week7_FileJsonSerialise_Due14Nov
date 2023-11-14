using System.Text.Json.Serialization;
using Week7_FileJsonSerialise_Due14Nov;
using Week7_FileJsonSerialise_Due14Nov.Extentions;
using Week7_FileJsonSerialise_Due14Nov.Interfaces;
using Week7_FileJsonSerialise_Due14Nov.Ui;
using Week7_FileJsonSerialise_Due14Nov.UI;

//var DataFolderPath = "C:/Users/vuqar/Desktop/Data";
var DataFolderPath = Environment.ExpandEnvironmentVariables("%UserProfile%/Desktop/Data");


Directory.CreateDirectory(DataFolderPath);
var filepath = Path.Combine(DataFolderPath, "data.json");
if(!File.Exists(filepath))
    using (File.Create(filepath)) { }


ICustomCollectionFileBasedSource<Student> fileSource = new JsonFileSource<Student>(filepath);
StudentCollection studentCollection = new(fileSource);

var commands = new string[] {"Show All","Add Student","Update Student","Remove Student","Quit"};

int command;
do
{
    command = UiHelper.DisplayAndGetCommandBySelection(commands, "Choose command"); ;
    try
    {
        switch(command)
        {
            case 0:
                ConsoleHelpers.AddListToBuffer<Student>(await studentCollection.FetchAndGetItemsAsync());
                break;    
            case 1:
                var student = UiHelper.GetStudentFromConsole();
                await studentCollection.AddAsync(student);
                break;
            case 2:
                var code = UiHelper.PromptAndGetNonEmptyString("Code");
                var name = UiHelper.PromptAndGetNonEmptyString("Name");
                var surName = UiHelper.PromptAndGetNonEmptyString("Surname");
                await studentCollection.UpdateStudentByCodeAsync(code,new(name,surName,code));
                break;
            case 3:
                var studentCode = UiHelper.PromptAndGetNonEmptyString("Code");
                await studentCollection.RemoveStudentByCode(studentCode);
                break;  
        }
    }catch(Exception e)
    {
        ConsoleHelpers.BufferError(e.Message);
    }

} while (command != commands.Count() - 1);





