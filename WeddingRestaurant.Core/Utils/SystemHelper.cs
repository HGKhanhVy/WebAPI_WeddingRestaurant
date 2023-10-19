using Microsoft.Extensions.Configuration;
using WeddingRestaurant.Core.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Utils
{
    public class SystemHelper
    {
        public static SystemSettingModel Setting => SystemSettingModel.Instance;
        public static IConfiguration Configs => SystemSettingModel.Configs;
        public static string AppDb => SystemSettingModel.Configs.GetConnectionString("WeddingRestaurantConnection");
    }
}
