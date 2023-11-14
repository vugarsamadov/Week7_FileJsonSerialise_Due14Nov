using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7_FileJsonSerialise_Due14Nov.Interfaces;

namespace Week7_FileJsonSerialise_Due14Nov
{
    internal class StudentCollection : CustomSourceCollection<Student>
    {
        public StudentCollection(ICustomCollectionSource<Student> source) : base(source) { }

        public override async Task AddAsync(Student item)
        {
            if (await AnyAsync(s => s.Code == item.Code))
                throw new Exception("Student with code already present!");
            await base.AddAsync(item);
        }

        public async Task RemoveStudentByCode(string code)
        {
            var studentIndx = await MySingleOrExceptionAsync(s => s.Code == code);
            await RemoveAsync(Items[studentIndx]);
        }
    
        public async Task UpdateStudentByCodeAsync(string code, Student newStudent)
        {
            var oldStudentIndx = await MySingleOrExceptionAsync(s => s.Code == code);
            await SetAsync(oldStudentIndx, newStudent);
        }

    }
}
