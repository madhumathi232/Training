using System.ComponentModel;

namespace SampleApp1.Controllers
{
    public class Student:IStudent,INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        { 
            get
            {
                return _Id;
                
            }
            set
            { _Id = value; NotifyPropertyChanged("Id"); }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; NotifyPropertyChanged("Name"); }
        }
        private int _TotalMarks;
        public int TotalMarks { get { return _TotalMarks; } set { _TotalMarks = value;NotifyPropertyChanged("TotalMarks"); } }
        private float _Average;
        public float Average 
        {
            get { return _Average; } 
            set { _Average = value;NotifyPropertyChanged("Average"); } 
        }
        private char _Grade;
        private int _DeptId;
        public int DeptId { get { return _DeptId; } set { _DeptId = value;NotifyPropertyChanged("DeptId"); } }
        public event PropertyChangedEventHandler? _PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public char Grade { get { return _Grade; } set { _Grade = value; } }



    }
   
}
