using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public enum PersonType 
    {
        Parent,
        Child
        //public int PersonTypeId { get; set; }
        //[ForeignKey("Parent")]
        //public string PersonTypeValue { get; set; }
        
        //private string[] PersonTypeValues = {"Parent", "Child"};

        /*public PersonType(string personTypeValue)
        {
            PersonTypeValue = personTypeValue;
        }*/

        
        
        //[MaxLength(64)]
        //public string[] PersonTypeValue = {"Parent", "Child"};//{ get; set; } 
        
        //public ICollection<Person> Persons { get; set; }

        //public ICollection<Family> Families { get; set; }
    }
}