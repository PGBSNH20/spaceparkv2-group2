using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SpaceParkAPI.Dtos;

namespace SpaceParkAPI.Profiles
{
    public class SpaceParkPorfile:Profile
    {
        public SpaceParkPorfile()
        {
            CreateMap<Receipt, SpaceParkReadDto>();
        }


    }
}
