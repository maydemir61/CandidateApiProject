using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCKNValidation;

namespace Business.DtoMapper
{
    public  class CustomerProfile:Profile
    {
        bool identitynoValid;
        public CustomerProfile()
        {

            CreateMap<CustomerDto, Customer>().BeforeMap((src, dest) => ValidateIdentityNo(src))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.IdentityNo, opt => opt.MapFrom(src => src.IdentityNo))
                .ForMember(dest => dest.IdentityNoVerified, opt => opt.MapFrom(src => identitynoValid))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => identitynoValid));

            CreateMap<Customer, CustomerDto > ();
        }
        private async void ValidateIdentityNo(CustomerDto customer)
        {
            using (TCKNValidation.KPSPublicSoapClient service = new TCKNValidation.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
            {
                var response = await service.TCKimlikNoDogrulaAsync(Convert.ToInt64(customer.IdentityNo), customer.Name.ToUpper(), customer.Surname.ToUpper(), customer.BirthDate.Year);
                identitynoValid = response.Body.TCKimlikNoDogrulaResult;
            }
            
        }
    }
}
