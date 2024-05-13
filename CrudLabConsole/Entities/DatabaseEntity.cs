using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudLabConsole.Entities;

public class DatabaseEntity
{
    public List<Student> Students { get; set; } = [];
    public List<Teacher> Teachers { get; set; } = [];
    
}
