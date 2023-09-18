﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.EF.Logic.DTO;
using Practica3.EF.Logic.Validators;
using System;

namespace Practica3.EF.Logic.Tests
{
    [TestClass()]
    public class EmployeeValidatorTests
    {
        [TestMethod()]
        public void Validate_ValidEmployee()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto validEmployee = new EmployeesDto
            {
                FirstName = "Mayra",
                LastName = "Ric",
                City = "CityName",
                Country = "ARG"
            };

            // Act
            var validationErrors = employeeValidator.Validate(validEmployee);

            // Assert
            Assert.AreEqual(0, validationErrors.Count, "Validation should pass for a valid employee.");
        }

        [TestMethod()]
        public void Validate_InvalidFirstName()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "M",
                LastName = "Riccardi",
                City = "CityName",
                Country = "ARG"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(1, validationErrors.Count, "Validation should fail for an invalid first name.");
        }

        [TestMethod()]
        public void Validate_InvalidLastName()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "Mayra",
                LastName = "R",
                City = "CityName",
                Country = "ARG"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(1, validationErrors.Count, "Validation should fail for an invalid last name.");
        }

        [TestMethod()]
        public void Validate_InvalidCountry()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "Mayra",
                LastName = "Riccardi",
                City = "CityName",
                Country = "A"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(0, validationErrors.Count, "Validation should fail for an invalid country.");
        }

        [TestMethod()]
        public void Validate_FirstNameTooLong()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "aaaaaaaaaaaaaaaaaaa",
                LastName = "Riccardi",
                City = "CityName",
                Country = "Argentina"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(1, validationErrors.Count, "Validation should fail for an overly long first name.");
        }

        [TestMethod()]
        public void Validate_LastNameTooLong()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "Mayra",
                LastName = "Riccardiiiiiiiiiiiiiiiiiiii",
                City = "CityName",
                Country = "Argentina"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(1, validationErrors.Count, "Validation should fail for an overly long last name.");
        }

        [TestMethod()]
        public void Validate_CountryTooLong()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "Mayra",
                LastName = "Riccardi",
                City = "CityName",
                Country = "Argentinaaaaaaaaaaaaaaaaaaaaaaaaaa"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(1, validationErrors.Count, "Validation should fail for an overly long country.");
        }

        [TestMethod()]
        public void Validate_NameContainsNumbers()
        {
            // Arrange
            EmployeeValidator employeeValidator = new EmployeeValidator();
            EmployeesDto invalidEmployee = new EmployeesDto
            {
                FirstName = "Mayra",
                LastName = "Riccardi1",
                City = "CityName",
                Country = "Argentina"
            };

            // Act
            var validationErrors = employeeValidator.Validate(invalidEmployee);

            // Assert
            Assert.AreEqual(1, validationErrors.Count, "Validation should fail for a name containing numbers.");
        }
    }
}
