﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationsExample.CustomValidators;

namespace ModelValidationsExample.Models;

public class Person
{
    [Required(ErrorMessage = "{0} can't be empty or null")]
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
    [RegularExpression("^[A-Za-z .]$",
        ErrorMessage = "{0} must only contain alphanumeric characters, space and dot (.)")]
    public string? Name { get; set; }

    [EmailAddress(ErrorMessage = "{0} must be a valid email address")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "{0} must be a valid phone number")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "{0} can't be blank")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "{0} can't be blank")]
    [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
    public string? ConfirmPassword { get; set; }

    [Range(0, 999.99, ErrorMessage = "{0} must be between {1} and {2}")]
    [ValidateNever]
    public double? Price { get; set; }

    [MinimumYearValidator(2000, ErrorMessage = "Date of Birth should be newer than {0} year")]
    public DateTime? DateOfBirth { get; set; }

    public override string ToString()
    {
        return $"Person: {Name}, {Email}, {Phone}, {Password}, {ConfirmPassword}, {Price}";
    }
}