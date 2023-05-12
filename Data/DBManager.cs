using HRDepartamentMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HRDepartamentMVVM.Data
{
    public static class DBManager
    {
        /*
        public static void ExportDepartaments(string path)
        {
            PortDateBase portDateBase = new PortDateBase();
            portDateBase.Departaments = DateBase.Departaments;
            portDateBase.Employees = DateBase.Employees;

            string jsonString = JsonSerializer.Serialize(DateBase.Departaments);
            File.WriteAllText(path, jsonString);

        }

        public static void ImportDepartaments(string path)
        {
            string jsonString = File.ReadAllText(path);
            PortDateBase portDateBase = JsonSerializer.Deserialize<PortDateBase>(jsonString);
            DateBase.Departaments = portDateBase.Departaments;
            DateBase.Employees = portDateBase.Employees;
        }
        */
    }
}
