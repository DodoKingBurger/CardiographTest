using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardiographTest.Services.Controller.MECG.structs
{
  internal enum CTSCSE_Noise
  {
    CTSCSENoise_50HZ,        //!< 50Hz noise 25uV peak
    CTSCSENoise_60HZ,        //!< 60Hz noise 25uV peak
    CTSCSENoise_BL,          //!< Baseline noise 0.3Hz 0.5mV peak
    CTSCSENoise_BL_HF,       //!< Baseline noise 0.3Hz 0.5mV peak + HF noise 15uVrms
    CTSCSENoise_HF_05,       //!< HF noise 05uVrms
    CTSCSENoise_HF_10,       //!< HF noise 10uVrms
    CTSCSENoise_HF_15,       //!< HF noise 15uVrms
    CTSCSENoise_HF_20,       //!< HF noise 20uVrms
    CTSCSENoise_HF_25,       //!< HF noise 25uVrms
    CTSCSENoise_HF_30,       //!< HF noise 30uVrms
    CTSCSENoise_HF_35,       //!< HF noise 35uVrms
    CTSCSENoise_HF_40,       //!< HF noise 40uVrms
    CTSCSENoise_HF_45,       //!< HF noise 45uVrms
    CTSCSENoise_HF_50,       //!< HF noise 50uVrms
    CTSCSENoise_MAX          //!< Noise Off
  }
}
