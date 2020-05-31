using System;
using Contracts.DAL.Base;

namespace PublicApi.DTO.v1
{
    public class Family: IDomainEntityId
    {
        public Guid Id { get; set; }
        public int PersonCount { get; set; }
    }
}