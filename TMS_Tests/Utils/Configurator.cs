﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Tests.Utils
{
    internal class Configurator
    {
        public static AppSettings ReadConfiguration()
        {
            var appSettigsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            var appSettingsText = File.ReadAllText(appSettigsPath);
            return JsonConvert.DeserializeObject<AppSettings>(appSettingsText) ?? throw new FileNotFoundException();
        }
    }
}
