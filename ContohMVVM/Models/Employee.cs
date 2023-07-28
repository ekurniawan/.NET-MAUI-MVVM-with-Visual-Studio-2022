using System;
namespace ContohMVVM.Models
{
    public enum AccessLevel
    {
        Admin,
        User
    }

    public class Employee
    {
        string name;
        string resourceName;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (Photo == null && !String.IsNullOrEmpty(name))
                    Photo = ImageSource.FromFile(name.ToLower().Replace(" ", "_") + ".jpg");
            }
        }

        public Employee(string name)
        {
            this.Name = name;
        }
        public ImageSource Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public AccessLevel Access { get; set; }
        public bool OnVacation { get; set; }
    }
}

