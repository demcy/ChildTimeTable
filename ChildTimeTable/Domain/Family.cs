using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Family : Family<Guid>, IDomainEntityBaseMetadata
    {
        
    }
    public class Family<TKey> :  DomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual ICollection<Person>? Persons { get; set; }
    }
}