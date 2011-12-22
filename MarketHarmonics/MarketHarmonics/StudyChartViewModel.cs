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
using System.Windows.Threading;
namespace MarketHarmonics {
  public class StudyChartViewModel : INotifyPropertyChanged {
    int _CurrentIndex = 0;
    DispatcherTimer _DispatchTimer;
    ObservableCollection<StudyModel> _StudyModels;
    SimpleCommand _RunStudiesCommand;
    SimpleCommand _RunStudiesSoundCommand;
    public event EventHandler SoundLoaded;
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
    public virtual void OnSoundLoaded( object sender, EventArgs e ) {
      EventHandler handler = SoundLoaded;
      if( handler != null )
        handler( sender, e );
    }
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void Initialize() {
      _DispatchTimer = new DispatcherTimer();
      _DispatchTimer.Interval = new TimeSpan( 0, 0, 1 );
      _DispatchTimer.Tick += new EventHandler( _DispatchTimer_Tick );

      StudyModels = new ObservableCollection<StudyModel>();
      StudyModels.CollectionChanged += StudyModels_CollectionChanged;
      RunStudiesCommand = new SimpleCommand();
      RunStudiesCommand.MayBeExecuted = true;
      RunStudiesSoundCommand = new SimpleCommand();
      RunStudiesSoundCommand.Executed += new EventHandler( RunStudiesSoundCommand_Executed );
    }

    void _DispatchTimer_Tick( object sender, EventArgs e ) {
      SoundWaves.ForEach( x => {
        if( x.HasNextValue() )
          x.NextValue();
      } );
    }
    List<ISoundWaveGenerator> _SoundWaves;

    void RunStudiesSoundCommand_Executed( object sender, EventArgs e ) {
      List<ISoundWaveGenerator> wavs = new List<ISoundWaveGenerator>();
      StudyModels.ToList().ForEach( x => {
        var soundWave = new OscillationSoundWave();
        soundWave.SoundWaveData = x.PointModels.Select( y => y.Frequency + 200 );
        wavs.Add( soundWave );
      } );
      SoundWaves = wavs;
      OnSoundLoaded( this, EventArgs.Empty );
      _DispatchTimer.Start();
    }

    void StudyModels_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
      if( e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add ) {
        SetYAxisRange();
        RunStudiesSoundCommand.MayBeExecuted = true;
      }
    }
    public StudyChartViewModel() {
      Initialize();
    }

    
    public void PlotStudyModel( StudyModel data ) {
      //OnPloted( this, new EventArgs<StudyModel>( data ) );
      StudyModels.Add( data );
      
    }
    public SimpleCommand RunStudiesSoundCommand {
      get {
        return _RunStudiesSoundCommand;
      }
      set {
        _RunStudiesSoundCommand = value;
      }
    }
    public List<ISoundWaveGenerator> SoundWaves {
      get {
        return _SoundWaves;
      }
      set {
        if( _SoundWaves == value )
          return;
        _SoundWaves = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "SoundWaves" ) );
      }
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
