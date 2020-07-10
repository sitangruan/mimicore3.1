namespace mimicore3._1.Models
{
    public class ModulePermission
    {
        public int Index { get; set; }

        public string ModuleName { get; set; }

        public string RouterPath { get; set; }

        public string RouterName { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsVisible { get; set; }
    }
}
