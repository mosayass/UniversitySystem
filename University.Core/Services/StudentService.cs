using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.DTOs;
using University.Core.Forms;
using University.Data.Entities;
using University.Data.Repositries;

namespace University.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Create(CreateStudentForm form)
        {
            // Validation
            if (form==null)
            {
                throw new ArgumentException(nameof(form));
            }
            if (string.IsNullOrEmpty(form.Name))
            {
                throw new Exception("Name is required");
            }
            if (string.IsNullOrEmpty(form.Email))
            {
                throw new Exception("Email is required");
            }
            //Logic
            var student = new Student()
            { Email = form.Email ,
              Name=form.Name
            };
            // Saving
            _studentRepository.Create(student);
            _studentRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var student=_studentRepository.GetById(id);
            if (student == null)
            {
                throw new Exception("no such student");
            }
            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();
        }

        public List<StudentDTO> GetAll()
        {
            var allStudents=_studentRepository.GetAll();
            var dtos= allStudents.Select(Student => new StudentDTO() 
            {
                Id=Student.Id,
                Name=Student.Name,
                Email=Student.Email,
            }).ToList();
            return dtos;
        }

        public StudentDTO GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                throw new Exception("no such student");
            }
            var dto= new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
            };
            return dto;

        }

        public void Update(int id, UpdateStudentForm form)
        {
            // Validation
            if (form == null)
            {
                throw new ArgumentException(nameof(form));
            }
            if (string.IsNullOrEmpty(form.Name))
            {
                throw new Exception("Name is required");
            }
            var student=_studentRepository.GetById(id);
            if (student==null)
            {
                throw new Exception("No such student");
                
            }
            //Logic

            student.Name = form.Name;
            
            // Saving
            _studentRepository.Update(student);
            _studentRepository.SaveChanges();

        }
    }
    public interface IStudentService 
    {
        StudentDTO GetById(int id);
        List<StudentDTO> GetAll();
        void Create(CreateStudentForm form);
        void Update(int id,UpdateStudentForm form);
        void Delete(int id);
    }
}
