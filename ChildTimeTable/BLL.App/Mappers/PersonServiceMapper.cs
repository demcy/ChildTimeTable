using System;
using System.Collections;
using System.Linq;
using AutoMapper;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class PersonServiceMapper : BaseMapper<DALAppDTO.Person, BLLAppDTO.Person>, IPersonServiceMapper
    {
        public PersonServiceMapper():base()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.PersonDisplay, BLLAppDTO.PersonDisplay>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Person, BLLAppDTO.PersonDisplay>()
                .ForMember(item => item.LocationCount,
                    k=>
                        k.MapFrom(src=>src.Locations!.Count));
            
            
            MapperConfigurationExpression.CreateMap<BLLAppDTO.Person, DALAppDTO.Person>();
                //.ForMember(item=>item.Locations,
                //    o=>o.Ignore());

            MapperConfigurationExpression.CreateMap<DALAppDTO.Person, BLLAppDTO.Person>()
                .ForMember(item => item.Locations,
                    k => k.Ignore())
                .ForMember(item => item.RecipientNotifications,
                    k => k.Ignore())
                .ForMember(item => item.ParentObligations,
                    k => k.Ignore())
                //.ForMember(item => item.UnreadMessages,
                  //  k => k.MapFrom(src=>src.RecipientNotifications.Count()))
                .ForMember(item => item.ChildObligations,
                    k => k.Ignore());
            // add more mappings
            //MapperConfigurationExpression.CreateMap<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>();
            //MapperConfigurationExpression.CreateMap<DALAppDTO.GpsSessionType, BLLAppDTO.GpsSessionType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }

        public BLLAppDTO.PersonDisplay MapPersonDisplayToPersonDisplay(DALAppDTO.PersonDisplay inObject)
        {
            return Mapper.Map<BLLAppDTO.PersonDisplay>(inObject);


            //MapperConfigurationExpression.CreateMap<BLLAppDTO.PersonDisplay, DALAppDTO.PersonDisplay>();
        }
        
        public BLLAppDTO.PersonDisplay MapPersonToPersonDisplay(DALAppDTO.Person inObject)
        {
            return Mapper.Map<BLLAppDTO.PersonDisplay>(inObject);


            //MapperConfigurationExpression.CreateMap<BLLAppDTO.PersonDisplay, DALAppDTO.PersonDisplay>();
        }


        public BLLAppDTO.Person MapPersonDisplay(DALAppDTO.PersonDisplay inObject)
        {
            //return Mapper.Map<BLLAppDTO.Person>(inObject);
            var inProperties = inObject
                .GetType()
                .GetProperties()
                .ToDictionary(
                    key => key.Name,
                    val => val.GetValue(inObject));

            var result = new BLLAppDTO.Person();
            foreach (var property in result.GetType().GetProperties())
            {
                if (inProperties.TryGetValue(property.Name, out var value))
                {
                    if (property.PropertyType.IsEnum)
                    {
                        BLLAppDTO.PersonType pt = (BLLAppDTO.PersonType)Enum.Parse(typeof(BLLAppDTO.PersonType), (string)value!, true);
                        property.SetValue(result, pt);
                        continue;
                    }
                    if (value != null)
                    {
                        property.SetValue(result, value);
                    }
                    
                }
            }
            return result;
        }
        
        
    }
}