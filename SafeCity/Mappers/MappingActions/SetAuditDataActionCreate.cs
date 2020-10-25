using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using SafeCity.Core.Entities;
using SafeCity.DTOs;

namespace SafeCity.Mappers.MappingActions
{
    public class SetAuditDataActionCreate<TSource, TDestination> : IMappingAction<TSource, TDestination>
        where TSource : ProjectCreateDto
        where TDestination : AuditEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SetAuditDataActionCreate(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public void Process(TSource source, TDestination destination, ResolutionContext context)
        {
            //destination.CreatedBy = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
            destination.CreatedBy = "chuck.norris@gmail.com";
            destination.CreatedDate = DateTime.Now;
        }
    }
}
