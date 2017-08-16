using AutoMapper;

namespace tinc.Web.Infrastructure
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

                cfg.CreateMap<SE.DataTransfer.Sport, Models.Sport>();
                cfg.CreateMap<Models.Sport, SE.DataTransfer.Sport>();



            });

            Mapped = config.CreateMapper();
        }
    }
}
