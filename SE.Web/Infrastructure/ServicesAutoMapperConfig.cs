using AutoMapper;
using SE.Web.Models;

namespace SE.Web.Infrastructure
{
    public class ServicesAutoMapperConfig
    {
        private static IMapper _mapped;

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

                cfg.CreateMap<DataTransfer.Sport, Sport>();
                cfg.CreateMap<Sport, DataTransfer.Sport>();



            });

            Mapped = config.CreateMapper();
        }
    }
}
