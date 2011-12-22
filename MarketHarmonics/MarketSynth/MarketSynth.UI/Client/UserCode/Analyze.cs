using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication
{
    public partial class Analyze
    {
        partial void Indicator_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Indicator);
        }

        partial void Indicator_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Indicator);
        }

        partial void Analyze_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Indicator);
        }
    }
}