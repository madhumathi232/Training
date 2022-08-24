namespace SampleApp1.Controllers
{
    public class Department
    {
        private int _DeptId;
        public int DeptId
        {
            get { return _DeptId; }
            set
            {
                _DeptId = value;
            }

        }
        private string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                _DeptName = value;
            }

        }

    }
}