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
using System.Xml.Linq;
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
        if (MessageBox.Show(MECG20.Connected(5), "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
          MECG20.Load_mit_header(Environment.CurrentDirectory + "\\TestFile\\100.hea"); //
          if (Show_Header(MECG20.Header))
          {
            MECG20.Load_mit_database();
            MECG20.Output_waveform(0);
            Task.Delay(10);
            MECG20.Stop_output();
            MECG20.Free_ecg_header(MECG20.Header);
            MECG20.Disconnected();
          }
          else
            MessageBox.Show("заголовок пуст");
        }
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
     
    private bool Show_Header(ECG_HEADER header)
    {
      if (true)//header.Signal != IntPtr.Zero
      {
        string Message = string.Empty;
        //ECG_SIGNAL[] signals = new ECG_SIGNAL[header.NumberOfSignals];

        //for (int i = 0; i < header.NumberOfSignals; i++)
        //{
        //  IntPtr signalPtr = IntPtr.Add(header.Signal, i * Marshal.SizeOf<ECG_SIGNAL>());
        //  signals[i] = Marshal.PtrToStructure<ECG_SIGNAL>(signalPtr);
        //}
        //ECG_SIGNAL signals = new ECG_SIGNAL();
        //signals = Marshal.PtrToStructure<ECG_SIGNAL>(header.Signal);

        Message = Encoding.ASCII.GetString(header.RecordName).Trim('\0');
        //Message +="/" + Encoding.ASCII.GetString(header.Reserved).Trim('\0');
        //List<string> strings = new List<string>
        //{
        //  Encoding.ASCII.GetString(header.RecordName).Trim('\0'),
        //  $"{header.NumberOfSignals}",
        //  $"{header.SamplingFrequency}",
        //  $"{header.NumberOfSamplesPerSignal}",
        //  Encoding.ASCII.GetString(header.Reserved),
        //  Encoding.ASCII.GetString(header.Reserved),
        //  //signals.Description.ToString(),
        //  //signals.MappingLead.ToString()
        //  //string.Join(", ", signals.Select(m => m.Description.ToString())),
        //  //string.Join(", ", signals.Select(m => m.MappingLead.ToString()))
        //};
        ECG_SIGNAL[] signals = header.GetSignalArray();
        for (int i = 0; i < header.NumberOfSignals; i++)
        {
          Message += $"[{i}] - {signals[i].MappingLead} {signals[i].Description} ";
        }
        return MessageBox.Show("Информация", Message, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
      }
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
