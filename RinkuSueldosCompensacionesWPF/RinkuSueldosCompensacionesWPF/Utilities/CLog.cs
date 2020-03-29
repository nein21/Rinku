using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RinkuSueldosCompensacionesWPF.Utilities
{   
    class CLog
    {
        private string NombreLog = "";
        private CLog()
        {
            obtenerNombreLog();
        }
        public static CLog GetObjLog()
        {
            return new CLog();
        }
        private void obtenerNombreLog()
        {
            string sArchivo = string.Empty;
            string sFecha = DateTime.Today.Year.ToString().PadLeft(4, '0') +
                            DateTime.Today.Month.ToString().PadLeft(2, '0') +
                            DateTime.Today.Day.ToString().PadLeft(2, '0');           
            sArchivo = Definiciones.NombreLog + sFecha + ".log";

            NombreLog =  sArchivo; // Valor de retorno
        }
   
        public void escribirLog(string sMensaje)
        {         
            string sArchivo = "";  
            if (!Directory.Exists("C:/Temp/log/"))
            {             
                Directory.CreateDirectory("C:/Temp/log/");
            }
         
            sArchivo = "C:/Temp/log/" + NombreLog;
            
            if (sMensaje.Length > 0)
            {               
                sMensaje = "[" + DateTime.Now.ToString() + "]\t" + sMensaje;
                try
                {                  
                    StreamWriter sr = File.AppendText(sArchivo);               
                    sr.WriteLine(sMensaje);                  
                    sr.Flush();             
                    sr.Close();
                }
                catch { }
            }
        }
    }
    
}
