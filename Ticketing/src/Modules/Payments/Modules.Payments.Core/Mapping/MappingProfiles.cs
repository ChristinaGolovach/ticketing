using AutoMapper;
using Modules.Payments.Core.Models;
using Modules.Payments.Data.Entities;

namespace Modules.Payments.Core.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Payment, ViewPaymentDto>();
        }
    }
}
