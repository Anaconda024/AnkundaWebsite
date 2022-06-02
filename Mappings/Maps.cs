using AnkundaWebsite2.Data;
using AnkundaWebsite2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkundaWebsite2.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Interact, InteractVM>().ReverseMap();
        }
    }
}
