using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Services.Controller.MECG.structs
{
  /// <summary>
  /// Фильтр шумов
  /// </summary>
  public enum CTSCSE_Noise
  {
    /// <summary>
    /// 50Hz noise 25uV peak
    /// </summary>
    CTSCSENoise_50HZ,       

    /// <summary>
    /// 60Hz noise 25uV peak
    /// </summary>
    CTSCSENoise_60HZ,        

    /// <summary>
    /// Baseline noise 0.3Hz 0.5mV peak
    /// </summary>
    CTSCSENoise_BL, 

    /// <summary>
    /// Baseline noise 0.3Hz 0.5mV peak + HF noise 15uVrms
    /// </summary>
    CTSCSENoise_BL_HF,

    /// <summary>
    /// HF noise 05uVrms
    /// </summary>
    CTSCSENoise_HF_05,

    /// <summary>
    /// HF noise 10uVrms
    /// </summary>
    CTSCSENoise_HF_10,       

    /// <summary>
    /// HF noise 15uVrms
    /// </summary>
    CTSCSENoise_HF_15,

    /// <summary>
    /// HF noise 20uVrms
    /// </summary>
    CTSCSENoise_HF_20,

    /// <summary>
    /// HF noise 25uVrms
    /// </summary>
    CTSCSENoise_HF_25,

    /// <summary>
    /// HF noise 30uVrms
    /// </summary>
    CTSCSENoise_HF_30,

    /// <summary>
    /// HF noise 35uVrms
    /// </summary>
    CTSCSENoise_HF_35,

    /// <summary>
    /// HF noise 40uVrms
    /// </summary>
    CTSCSENoise_HF_40,

    /// <summary>
    /// HF noise 45uVrms
    /// </summary>
    CTSCSENoise_HF_45,
    
    /// <summary>
    /// HF noise 50uVrms
    /// </summary>
    CTSCSENoise_HF_50,

    /// <summary>
    /// Noise Off
    /// </summary>
    CTSCSENoise_MAX
  }
}
