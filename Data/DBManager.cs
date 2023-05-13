using HRDepartamentMVVM.Models;
using HRDepartamentMVVM.ViewModels;
using Microsoft.Win32;
using Newtonsoft.Json;
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
        public static string GetOpenFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetSaveFilePath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        public static void Export()
        {
            string jsonString = JsonConvert.SerializeObject(Data.DataBase, Formatting.Indented);
            File.WriteAllText(GetSaveFilePath(), jsonString);
        }

        public static void Import()
        {
            string jsonString = File.ReadAllText(GetOpenFilePath());
            DataBase dataBaseJson = JsonConvert.DeserializeObject<DataBase>(jsonString);
            Data.DataBase = dataBaseJson;
        }
    }
}
