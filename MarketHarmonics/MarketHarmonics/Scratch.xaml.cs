using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MarketSynth.Services;
using System.ServiceModel.DomainServices.Client;
namespace MarketHarmonics {
  public partial class Scratch : UserControl {
    public Scratch() {
      InitializeComponent();
    }
    List<MarketSynth.Services.PointData> _Points = new List<PointData>();
    private void pointDataDomainDataSource_LoadedData( object sender, System.Windows.Controls.LoadedDataEventArgs e ) {

      if( e.HasError ) {
        System.Windows.MessageBox.Show( e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK );
        e.MarkErrorAsHandled();
      }
    }

    private void pointDataDomainDataSourceLoadButton_Click( object sender, RoutedEventArgs e ) {
      pointDataDomainDataSource.Load();
      //var ctx = new MarketSynthDomainContext.MarketSynthDomainContextEntityContainer();
      //var entities = ctx.GetEntitySet<MarketSynth.Services.PointData>();
      //ctx.LoadEntities( entities );
     // EntityQuery<PointData> ea = 
      //var asyncResult = this.pointDataDomainDataSource.DomainContext.DomainClient.BeginQuery( new System.ServiceModel.DomainServices.Client.EntityQuery<MarketSynth.Services.PointData>(), pointDataDomainDataSource_LoadedData, _Points );
    }
  }
}
