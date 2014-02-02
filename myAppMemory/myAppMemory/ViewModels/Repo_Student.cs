using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myAppMemory.Models;

namespace myAppMemory.ViewModels {
  public class Repo_Student {
    public Repo_Student() {
      this.Students = (List<Student>)HttpContext.Current.Application["Students"];
    }

    public IEnumerable<StudentsForList> getForList() {
      var ls = this.Students.OrderBy(n => n.Id);

      List<StudentsForList> rls = new List<StudentsForList>();

      foreach (var item in ls) {
        StudentsForList stu = new StudentsForList();
        stu.StudentId = item.Id;
        stu.StudentNumber = item.StudentNumber;
        rls.Add(stu);
      }

      return rls;
    }

    public StudentPublic getStudentPublic(int? id) {
      var st = Students.FirstOrDefault(n => n.Id == id);

      StudentPublic stu = new StudentPublic();
      stu.FirstName = st.FirstName;
      stu.LastName = st.LastName;
      stu.Phone = st.Phone;
      stu.StudentNumber = st.StudentNumber;

      return stu;

    }

    //public IEnumerable<StudentPublic> getStudentsPublic()

    public StudentFull createStudent(StudentFull st) {
      Student stu = new Student(st.FirstName, st.LastName, st.Phone, st.StudentNumber);
      stu.Id = Students.Max(n => n.Id) + 1;
      Students.Add(stu);
      return st;
    }

    public List<Student> Students { get; set; }
  }
}