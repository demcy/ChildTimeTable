using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using AutoMapper;
using Contracts.BLL.Base.Mappers;


namespace BLL.Base.Mappers
{
    public class BaseBLLMapper<TInObject, TOutObject> : IBaseBLLMapper<TInObject, TOutObject>
        where TInObject : class, new()
        where TOutObject : class, new()

    {
        private readonly IMapper _mapper;

        public BaseBLLMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<TInObject, TOutObject>();
                config.CreateMap<TOutObject, TInObject>();
            }).CreateMapper();
        }

        public TOutObject Map(TInObject inObject)
        {
            return _mapper.Map<TInObject, TOutObject>(inObject);
            
        }

        public TMapOutObject Map<TMapInObject, TMapOutObject>(TMapInObject inObject)
            where TMapInObject : class, new()
            where TMapOutObject : class, new()
        {
            //return _mapper.Map<TMapInObject, TMapOutObject>(inObject);
            var inProperties = inObject
                .GetType()
                .GetProperties()
                .ToDictionary(
                    key => key.Name,
                    val => val.GetValue(inObject));

            var result = new TMapOutObject();
            foreach (var property in result.GetType().GetProperties())
            {
                if (inProperties.TryGetValue(property.Name, out var value))
                {
                    if (property.PropertyType.IsClass && !typeof(string).IsAssignableFrom(property.PropertyType))
                    {
                        if (value != null)
                        {


                            var r = GetType().GetMethods();
                            var cc = r[1].MakeGenericMethod(inProperties[property.Name].GetType(),
                                property.PropertyType);
                            var dd = cc.Invoke(this, new[] {value});

                            property.SetValue(result, dd);
                        }
                        
                        /*MethodInfo dynMethod = GetType().GetMethod(nameof(Map), 
                            BindingFlags.Instance | BindingFlags.Public,
                            null, new[] {property.PropertyType},null);
                         var y = dynMethod!.Invoke(this, new[] {value});*/
                        //var x = GetType().GetMethod(nameof(Map))!.MakeGenericMethod(property.PropertyType)

                        /*property.SetValue(result, GetType()
                            .GetMethod("Map")!
                            .MakeGenericMethod(property.PropertyType)
                            .Invoke(this, new[] {value}));*/
                        continue;
                    }
                    
                    if (typeof(string).IsAssignableFrom(property.PropertyType))
                    {
                        property.SetValue(result, value);
                        continue;
                    }
                    else
                    {
                        property.SetValue(result, value);
                        continue;
                    }
                }

            }
            return result;
        }
    }
}