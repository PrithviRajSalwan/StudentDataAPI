using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataAPI.Models
{
    public class SubjectData
    {

        [Key]
        public int StudentId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public String SubjectName { get; set; }


        [Column(TypeName = "nvarchar(5)")]
        public int SubjectMarks { get; set; }

    }
}
