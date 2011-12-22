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
using System.ComponentModel;
using MarketSynth.Services;
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;
namespace MarketHarmonics {
  public class StudyChartViewModel : INotifyPropertyChanged {

    ObservableCollection<StudyModel> _StudyModels;
    SimpleCommand _RunStudiesCommand;
    public SimpleCommand RunStudiesCommand {
      get {
        return _RunStudiesCommand;
      }
      set {
        if( _RunStudiesCommand == value )
          return;
        _RunStudiesCommand = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "RunStudiesCommand" ) );
      }
    }
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void Initialize() {
      StudyModels = new ObservableCollection<StudyModel>();
      StudyModels.CollectionChanged += StudyModels_CollectionChanged;
      RunStudiesCommand = new SimpleCommand();
      RunStudiesCommand.MayBeExecuted = true;
    }

    void StudyModels_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
      if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        SetYAxisRange();
    }
    public StudyChartViewModel() {
      Initialize();
    }

    //public event EventHandler<EventArgs<StudyModel>> Ploted;
    public void PlotStudyModel( StudyModel data ) {
      //OnPloted( this, new EventArgs<StudyModel>( data ) );
      StudyModels.Add( data );
      
    }
    public ObservableCollection<StudyModel> StudyModels {
      get {
        return _StudyModels;
      }
      set {
        if( _StudyModels == value )
          return;
        _StudyModels = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "StudyModels" ) );
      }
    }
    void SetYAxisRange() {
      var points = new List<double>();
      StudyModels.ToList().ForEach( x => {
        points.AddRange( x.PointModels.Select( y => y.YAxisValue ) );
      } );
      YAxisMaxValue = points.Max();
      YAxisMinValue = points.Min();
    }
    double _YAxisMinValue;
    public double YAxisMinValue {
      get { return _YAxisMinValue; }
      set {
        if( _YAxisMinValue == value )
          return;
        _YAxisMinValue = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs("YAxisMinValue") );
      }
    }
    double _YAxisMaxValue;
    public double YAxisMaxValue {
      get { return _YAxisMaxValue; }
      set {
        if( _YAxisMaxValue == value )
          return;
        _YAxisMaxValue = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs("YAxisMaxValue") );
      }
    }
    
  }
}
