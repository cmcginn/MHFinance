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
    public partial class CreateNewStudy
    {

      partial void AddStudy_Execute() {
        var data = this.Studies.AddNew();
        data.Id = Guid.NewGuid();
        data.IndicatorId = this.DataWorkspace.MarketSynthDomainServiceData.Indicators.Where( x => x.Name == this.IndicatorProperty.Name ).Single().Id;
        data.InstrumentName = this.InstrumentName;        
        
      }

      partial void RunStudies_Execute() {
        this.Studies.ToList().ForEach(x=>{
          this.DataWorkspace.MarketSynthDomainServiceData.GetStudyIndicator( x.InstrumentName, x.IndicatorName );
        });
        Application.ShowStudyResults();
      }
    }
}