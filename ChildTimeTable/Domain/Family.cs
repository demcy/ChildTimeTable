using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Family : Family<Guid>, IDomainEntity
    {
        
    }
    public class Family<TKey> :  DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual ICollection<Person>? Persons { get; set; }
    }
}