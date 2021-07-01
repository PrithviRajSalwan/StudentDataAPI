using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataAPI.Models
{
    public class StudentDetail
    {
        [Key]
        public int StudentId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String FirstName { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public String LastName { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string Class { get; set; }

        public List<SubjectData> SubjectDataList { get; set; }

    }
}
