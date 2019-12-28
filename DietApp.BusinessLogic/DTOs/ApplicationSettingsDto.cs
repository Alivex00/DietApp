using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.BusinessLogic.DTOs
{
    public class ApplicationSettingsDto
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
