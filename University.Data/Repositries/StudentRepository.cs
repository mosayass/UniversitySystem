using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Context;
using University.Data.Entities;

namespace University.Data.Repositries
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _context;
        public StudentRepository(UniversityDbContext context) 
        {
            _context = context;
            
        }

        public void Create(Student student)
        {
            if (student==null)
            {
                throw new ArgumentNullException(nameof(student));
                
            }
            student.LastUpdatedTime = DateTime.Now;
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Students.Remove(student);

        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID value.", nameof(id));

            var student = _context.Students.Find(id);

            return student == null ? throw new KeyNotFoundException($"Student with Id {id} was not found.") : student;
        }

        public void Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));

            }
            student.LastUpdatedTime = DateTime.Now;
            _context.Students.Update(student);

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
    public interface IStudentRepository 
    {
        Student GetById(int id);
        List<Student> GetAll();
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        void SaveChanges();
    }
}
