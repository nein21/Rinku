using RinkuSueldosCompensacionesWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinkuSueldosCompensacionesWPF.ViewModel
{
    public class StudentViewModel
    {

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Mark", LastName = "Allain", Fucklogic = "fuck1" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brown", Fucklogic = "fuck2" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski", Fucklogic = "fuck3" });
            students.Add(new Student { FirstName = "nein", LastName = "hife", Fucklogic = "fuck4" });

            Students = students;
        }
    }
}
