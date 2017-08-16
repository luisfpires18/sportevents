using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE.DataTransfer;

namespace tinc.Business.Code
{
    public class Mapping
    {
        private static IMapper _mapped = null;

        public static IMapper Mapped
        {
            get
            {
                if (_mapped != null) return _mapped;
                CreateMaps();
                return _mapped;
            }
            set { _mapped = value; }
        }


        private static void CreateMaps()
        {

            var config = new MapperConfiguration(cfg =>
            {

                // Sport;
                cfg.CreateMap<Domain.Entities.Sport, Sport>();
                cfg.CreateMap<Sport, Domain.Entities.Sport>();
                


            });

            Mapped = config.CreateMapper();
        }
    }
}