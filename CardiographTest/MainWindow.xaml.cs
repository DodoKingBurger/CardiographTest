using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardiographTest.Controller;
using CardiographTest.Services.Controller.MECG.structs;

namespace CardiographTest
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Поля и свойства

    private MECG MECG20;

    #endregion

    #region Методы
    
    /// <summary>
    /// Загрузка окна.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
      try
      {
        MECG20 = new MECG();
        if (MessageBox.Show("Информация", MECG20.Connected(5), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
          MECG20.Load_mit_header(Environment.CurrentDirectory + "\\100.hea");
          if (Show_Header(MECG20.Header))
          {
            MECG20.Load_mit_database();
            MECG20.Output_waveform(0);
            Task.Delay(10);
            MECG20.Stop_output();
            MECG20.Free_ecg_header(MECG20.Header);
            MECG20.Disconnected();
          }
        }
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
     
    private bool Show_Header(ECG_HEADER header)
    {
      List<string> strings = new List<string>
      {
        string.Join("",header.RecordName),
        $"{header.NumberOfSignals}",
        $"{header.SamplingFrequency}",
        $"{header.NumberOfSamplesPerSignal}",
        $"{header.NumberOfSamplesPerSignal}",
        Encoding.UTF8.GetString(header.Reserved),
        string.Join(", ", header.Signal.Select(m => m.Description.ToString())),
        string.Join(", ", header.Signal.Select(m => m.MappingLead.ToString()))
      };
      string Message = string.Empty; 
      foreach(var str in strings)
      {
        Message += str + "\n";
      }
      return MessageBox.Show("Информация", Message, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
    }
    #endregion

    #region Консутроры 

    public MainWindow()
    {
      InitializeComponent();
    }

    #endregion

  }
}
