using System;
using System.ComponentModel.DataAnnotations;

public class Name
{
    [Key] 
    public Guid Id { get; set; }
    public string full_name { get; set; }
    public string given_name { get; set; }
    public string surname { get; set; }
}