using AutoMapper;
using System.Reflection;

namespace CleanArchitectureTask.Application.Commons.Mapping
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper() { SetProfile(); }
        private void SetProfile()
        {
            var types = Assembly.GetAssembly(typeof(ProfileAutoMapper)).GetTypes();

            var mapscustom = ( from t in types
                               from i in t.GetInterfaces()
                               where typeof(IHaveCustomMapping).IsAssignableFrom(t) &&
                               !t.IsAbstract &&
                               !t.IsInterface
                               select (IHaveCustomMapping)Activator.CreateInstance(t) ).ToArray();

            foreach( var map in mapscustom )
            {
                map.SetProfiles(this);
            }
        }
    }
}
