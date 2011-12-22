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
using SilverSynth.Library;
namespace MarketSynth.Controls {
  public partial class MainPage : UserControl {
    public MainPage() {
      InitializeComponent();
    }
    MediaElement media = new MediaElement();
    StereoPcmStreamSource source = new StereoPcmStreamSource();
    Oscillator oscillator = new Oscillator() { Frequency = 440 };

    private void button1_Click( object sender, RoutedEventArgs e ) {

      source.Input = oscillator;
      media.SetSource( source );

    }

    private void button2_Click( object sender, RoutedEventArgs e ) {
      oscillator.Frequency = 880;
    }
  }
}
