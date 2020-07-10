using System.Collections.Generic;

namespace mimicore3._1.Models
{
    public class User
    {
        public string Name { get; set; }

        public List<ModulePermission> Modules { get; set; }
    }
}
