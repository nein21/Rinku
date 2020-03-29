using RinkuSueldosCompensacionesWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinkuSueldosCompensacionesWPF.Utilities
{
    class GetLog
    {

        private static CLog log;

        public static CLog LOG
        {
            get
            {
                if (log == null)
                {
                    log = CLog.GetObjLog();                  
                }
                log.escribirLog("[GetLog::LOG] ###### Obteniendo LOG ######");
                return log;
            }
        }

    }
}
