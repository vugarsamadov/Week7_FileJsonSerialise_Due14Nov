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

        public async Task RemoveStudentByCode(string code)
        {
            var studentIndx = await MySingleOrDefaultAsync(s => s.Code == code);
            await RemoveAsync(Items[studentIndx]);
        }
    
        public async Task UpdateStudentByCode(string code, Student newStudent)
        {
            var oldStudentIndx = await MySingleOrDefaultAsync(s => s.Code == code);
            await SetAsync(oldStudentIndx, newStudent);
        }

    }
}
