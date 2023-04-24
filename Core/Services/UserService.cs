using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        private AuthorizationService authService { get; set; }


        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }
        public void Register(RegisterDto payload)
        {
            var hashedPassword = authService.HashPassword(payload.Password);


            if (payload.Role == UserRole.Student)
                unitOfWork.Students.Insert(new DataLayer.Entities.Student
                {
                    FirstName = payload.FirstName,
                    LastName = payload.LastName,
                    Email = payload.Email,
                    Address = payload.Address,
                    ClassId = payload.ClassId,
                    DateOfBirth = payload.DateOfBirth,
                    Grades = new List<Grade>(),
                    PasswordHash = hashedPassword,
                    Role = UserRole.Student,
                });
            unitOfWork.User.Insert(new DataLayer.Entities.User
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                Email = payload.Email,
                Address = payload.Address,
                ClassId = payload.ClassId,
                DateOfBirth = payload.DateOfBirth,
                PasswordHash = hashedPassword,
                Role = UserRole.Professor,
            });
        }
        public string ValidateLogin(LoginDto payload)
        {


            return default(string);
        }
    }
}
