using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace MarketHarmonics {
  public class MarketAnalyticsPresentationModel:INotifyPropertyChanged {
    public MarketAnalyticsPresentationModel() {
      Initialize();
    }

    protected virtual void Initialize() {
      PropertyChanged += MarketAnalyticsPresentationModel_PropertyChanged;
    }

    void MarketAnalyticsPresentationModel_PropertyChanged( object sender, PropertyChangedEventArgs e ) {
      switch( e.PropertyName ) {
        case "StudyChartViewModel":
          StudyChartViewModel.RunStudiesCommand.Executed += RunStudiesCommand_Executed;
          break;
        default:
          break;
      }
    }

    void RunStudiesCommand_Executed( object sender, EventArgs e ) {
      MarketStudiesViewModel.Studies.ToList().ForEach( x => {
        var model = (( MarketStudyViewModel )x.DataContext ).StudyModel;
        model.StudyDataLoaded += model_StudyDataLoaded;
        model.LoadStudyData();
      } );
    }

    void model_StudyDataLoaded( object sender, EventArgs e ) {
      var data = sender as StudyModel;
      if( data != null )
        StudyChartViewModel.PlotStudyModel( data );
    }


    #region ViewModels
   
    StudyChartViewModel _StudyChartViewModel;
    MarketStudiesViewModel _MarketStudiesViewModel;


    public MarketStudiesViewModel MarketStudiesViewModel {
      get {
        return _MarketStudiesViewModel;
      }
      set {
        if( _MarketStudiesViewModel == value )
          return;
        _MarketStudiesViewModel = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "MarketStudiesViewModel" ) );
      }
    }
    public StudyChartViewModel StudyChartViewModel {
      get {
        return _StudyChartViewModel;
      }
      set {
        if( _StudyChartViewModel == value )
          return;
        _StudyChartViewModel = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "StudyChartViewModel" ) );
      }
    }
    #endregion

    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}
