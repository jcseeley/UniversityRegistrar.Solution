using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
  public class EnrollmentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    
    public EnrollmentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
      ViewBag.PageTitle = "Enrollments";
      return View(_db.Enrollments.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
      ViewBag.PageTitle = " Add Enrollment";
      return View();
    }

    [HttpPost]
    public ActionResult Create(int studentId, int courseId)
    {
      _db.Enrollments.Add(new Enrollment() { StudentId = studentId, CourseId = courseId });
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }  
}