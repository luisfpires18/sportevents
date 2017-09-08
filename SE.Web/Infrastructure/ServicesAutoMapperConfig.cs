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

                cfg.CreateMap<DataTransfer.Event, Event>();
                cfg.CreateMap<Event, DataTransfer.Event>();

                cfg.CreateMap<DataTransfer.Competition, Competition>();
                cfg.CreateMap<Competition, DataTransfer.Competition>();
                


            });

            Mapped = config.CreateMapper();
        }
    }
}
