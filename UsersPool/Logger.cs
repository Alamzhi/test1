using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UsersPool
{
    public class Logger
    {
        private static readonly string sSource = "UsersPool App";
        private static readonly string sLog = "Application";
        public static void WriteInEventLog(string message)
        {
            try
            {
                if (!EventLog.SourceExists(sSource))
                {
                    EventLog.CreateEventSource(sSource, sLog);
                }
                EventLog.WriteEntry(sSource, message);
            }
            catch (SecurityException )
            {
                //если не пишет в EventLog - значит нет доступа. Ошибку не вываливаем.
                //Такие события не должны влиять на работоспособность программы и пугать пользователя
                //ignore
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
