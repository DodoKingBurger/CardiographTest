using System;
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

namespace CardiographTest
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Поля и свойства

    #endregion

    #region Методы
    
    /// <summary>
    /// Загрузка окна.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {

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
