using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServiceBackupRestore
    {
        public static void BackupBD(string dir)
        {
            try
            {
                Acceso acceso = new Acceso();
                string cmd;
                string subdir = dir.Substring(dir.Length -2,2);
                if (subdir.Equals(":\\"))
                {
                    cmd = "BACKUP DATABASE [TallerAdminDB] TO DISK='" + dir + "TallerAdmin" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                }
                else
                {
                    cmd = "BACKUP DATABASE [TallerAdminDB] TO DISK='" + dir + "\\" + "TallerAdmin" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                }
                acceso.Ejecutar(cmd);
            }
            catch 
            {
                throw new Exception("Error contra la base de datos al realizar el Backup");
            }
        }

        public static void RestoreBD(string arch)
        {
            try
            {
                Acceso acceso = new Acceso();

                string exec1 = "ALTER DATABASE [TallerAdminDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                acceso.Ejecutar(exec1);

                string exec2 = "USE MASTER RESTORE DATABASE [TallerAdminDB] FROM DISK='" + arch + "' WITH REPLACE;";
                acceso.Ejecutar(exec2);

                string exec3 = "ALTER DATABASE [TallerAdminDB] SET MULTI_USER";
                acceso.Ejecutar(exec3);
            }
            catch
            {
                throw new Exception("Error contra la base de datos al realizar el Restore");
            }
        }


    }
}
