using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketSynth.Services {
  public static class DomainHelper {
    public static void AssignFrequencies( this List<PointData> pointData ) {
      var max = pointData.Max( x => x.Point );
      pointData.ToList().ForEach( x => {
        x.Frequency = (( x.Point / max ) * 500)/100;
      } );
    }
    public static List<PointData> GetOpenPointData( this List<MarketData> marketData ) {
      return marketData.Select( x => new PointData { Id = Guid.NewGuid(), Point = ( double )x.Open, Date = x.MarketDate } ).ToList();
    }
    public static List<PointData> GetClosePointData( this List<MarketData> marketData ) {
      return marketData.Select( x => new PointData { Id = Guid.NewGuid(), Point = ( double )x.Close, Date = x.MarketDate } ).ToList();
    }
  }
}
