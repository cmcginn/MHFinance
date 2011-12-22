using Common.Net;
namespace MarketSynth.Services {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.Linq;
  using System.Data.Entity;
  using System.ServiceModel.DomainServices.Hosting;
  using System.ServiceModel.DomainServices.Server;


  public class MarketData {
    [Key]
    public Guid Id { get; set; }
    public DateTime MarketDate { get; set; }
    public Decimal Open { get; set; }
    public Decimal Close { get; set; }
    public Decimal High { get; set; }
    public Decimal Low { get; set; }
    public long Volume { get; set; }
  }

  public class Study {
    [Key]
    public Guid Id { get; set; }
    public Guid IndicatorId { get; set; }
    public string InstrumentName { get; set; }
  }

  public class Indicator {
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
  }

  public class StudyIndicator {
    [Key]
    public Guid Id { get; set; }
    public string Label { get; set; }
    public string PointData { get; set; }
  }

  public class PointData {
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double Point { get; set; }
    public double Frequency { get; set; }
  }

 
  [EnableClientAccess()]
  public class MarketSynthDomainService : DomainService {

    static List<StudyIndicator> _StudyIndicators = new List<StudyIndicator>();
    List<Study> _Studies;
    List<Indicator> _Indicators;
    public MarketSynthDomainService() {
      _Studies = new List<Study>();
      _Indicators = new List<Indicator> {
        new Indicator{Id=new Guid("fae9cfa5-26cb-45fa-b6ed-9f46e7a9b402"),Name="Market" },
        new Indicator{Id=new Guid("82906e76-4873-4fbf-b336-02ab7ea39b5c"),Name="SMA 20"}
      };
    }

    #region MarketData
    [Query( IsDefault = true )]
    public IQueryable<MarketData> GetMarketData() {
      return new List<MarketData>().AsQueryable();
    }
    public IQueryable<MarketData> GetMarketDataBySymbol( string symbol ) {
      var result = new List<MarketData>();
      if( !String.IsNullOrEmpty( symbol ) ) {
        var post = new HttpPost();
        post.PostUri = new Uri( String.Format( "http://www.google.com/finance/historical?q={0}&output=csv", symbol.ToUpper() ) );
        var response = new String( post.Post().Select( n => ( char )n ).ToArray() );
        response.Split( System.Environment.NewLine.ToCharArray() ).Skip( 1 ).ToList().ForEach( x => {
          var records = x.Split( ',' );
          if( records.Length == 6 ) {
            var dt = records[ 0 ].Split( '-' );
            result.Add( new MarketData {
              Id = Guid.NewGuid(),
              MarketDate = DateTime.Parse( String.Format( "{0} {1} 20{2}", dt[ 1 ], dt[ 0 ], dt[ 2 ] ) ),
              Open = Decimal.Parse( records[ 1 ] ),
              Close = Decimal.Parse( records[ 4 ] ),
              High = Decimal.Parse( records[ 2 ] ),
              Low = Decimal.Parse( records[ 3 ] ),
              Volume = long.Parse( records[ 5 ] )
            } );
          }
        } );
      }
      return result.OrderBy( n => n.MarketDate ).AsQueryable();
    }
    #endregion

    [Query( IsDefault = true )]
    public IQueryable<Indicator> GetIndicators() {
      return _Indicators.AsQueryable();
    }
    [Query( IsDefault = true )]
    public IQueryable<Study> GetStudies() {
      return _Studies.AsQueryable();
    }
    [Query( IsDefault = true )]
    public IQueryable<StudyIndicator> GetStudyIndicators() {
      return MarketSynthDomainService._StudyIndicators.AsQueryable();
    }

    public void AddStudy( Study study ) {
    }

    public IQueryable<PointData> GetPointData( string instrument, string indicator ) {
      var marketData = GetMarketDataBySymbol( instrument ).ToList();
      List<PointData> pointData = null;
      switch( indicator.ToUpper() ) {
        case "CLOSE PRICE":
          pointData = marketData.GetClosePointData();
          break;
        case "OPEN PRICE":
          pointData = marketData.GetOpenPointData();
          break;
        default:
          break;
      }
      pointData.AssignFrequencies();
      return pointData.AsQueryable();
    }


  }
}


