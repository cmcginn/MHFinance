using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication {
  public partial class Study {
    partial void IndicatorName_Compute( ref string result ) {
      var item = DataWorkspace.MarketSynthDomainServiceData.Indicators.Where( x => x.Id == this.IndicatorId ).SingleOrDefault();
      if( item != null )
        result = item.Name;


    }
  }
}
