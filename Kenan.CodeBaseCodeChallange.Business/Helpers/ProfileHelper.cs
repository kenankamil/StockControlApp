using AutoMapper;
using Kenan.CodeBaseCodeChallange.Business.Mapping.AutoMapper;

namespace Kenan.CodeBaseCodeChallange.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {

            return new List<Profile>
            {
                new ProductProfile(),
                new ProductSaleProfile(),
            };
        }
    }
}
