using AutoMapper;
using SE.DataTransfer;

namespace SE.Business.Code
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

                // Event;
                cfg.CreateMap<Domain.Entities.Event, Event>();
                cfg.CreateMap<Event, Domain.Entities.Event>();

                // Competition;
                cfg.CreateMap<Domain.Entities.Competition, Competition>();
                cfg.CreateMap<Competition, Domain.Entities.Competition>();



            });

            Mapped = config.CreateMapper();
        }
    }
}