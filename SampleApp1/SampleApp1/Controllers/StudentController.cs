using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace SampleApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public static List<Student> Students = new List<Student>();
        public static List<Department> Departments = new List<Department>();
        [HttpGet]
         [Route("GetStudentInfo")]

        public Student GetStudent(int Id)
        {

            return Students.Find(x => x.Id.Equals(Id));
        }
        [HttpPost]
        [Route("AddDeptInfo")]
        public IActionResult AddDepartment(int DeptId, string DeptName)
        {
            if (!Departments.Any(x => x.DeptId == DeptId))
            {
                Departments.Add(new Department { DeptId = DeptId, DeptName = DeptName });
                return Ok("Added");
            }
            else
                return BadRequest("Duplicate Info");
        }
        [HttpPut]
        [Route("UpdateDeptInfo")]
        public IActionResult ModifyDeptInfo(int Id, string DeptName)
        {
            if (!Departments.Any(x => x.DeptId == Id))
            {
                return BadRequest("No Data found");
            }
            try
            {
                Departments.Find(x => x.DeptId.Equals(Id)).DeptName = DeptName;
                return Ok("Modified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteDeptInfo")]
        public IActionResult DeleteDeptInfo(int Id)
        {
            if (!Departments.Any(x => x.DeptId == Id))
            {
                return BadRequest("No Data found");
            }
            try
            {
                var dept = Departments.Find(x => x.DeptId.Equals(Id));
                Departments.Remove(dept);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
        [HttpPost]
        [Route("AddStudentInfo")]
        public IActionResult AddStudents(int id, string name, int TotalMarks, char Grade, int DeptId)
        {

            if ((!Students.Any(x => x.Id == id)) && Departments.Any(x => x.DeptId.Equals(DeptId)))
            {
                Students.Add(new Student { Id = id, Name = name, TotalMarks = TotalMarks, Average = TotalMarks / 5, Grade = Grade, DeptId = DeptId });
                return Ok("Added");
            }
            else if (!Departments.Any(x => x.DeptId.Equals(DeptId)))
                return BadRequest("Invalid DepartmentId");
            else
                return BadRequest("Duplicate Records Found");

        }
        [HttpPut]
        [Route("UpdateStudentInfo")]
        public IActionResult ModifyStudentInfo(int Id, char Grade)
        {
            if (!Students.Any(x => x.Id == Id))
            {
                return BadRequest("No Data found");
            }
            try
            {
                Students.Find(x => x.Id.Equals(Id)).Grade = Grade;
                return Ok("Modified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
        [HttpPut]
        [Route("UpdateDeptStudentInfo")]
        public IActionResult ModifyStudentDeptInfo(int Id, int DeptId)
        {
            if (!(Students.Any(x => x.Id == Id) && Departments.Any(x => x.DeptId.Equals(DeptId))))
            {
                return BadRequest("Invalid Data");
            }
            try
            {
                Students.Find(x => x.Id.Equals(Id)).DeptId = DeptId;
                return Ok("Modified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteStudentInfo")]
        public IActionResult DeleteStudentInfo(int Id)
        {
            if (!Students.Any(x => x.Id == Id))
            {
                return BadRequest("No Info Found");
            }
            try
            {
                Student m = Students?.Where(x => x.Id.Equals(Id)).Select(x => x).First();
                Students.Remove(m);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

    }
}