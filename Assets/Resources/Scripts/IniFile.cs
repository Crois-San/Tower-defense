using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
 
/// <summary>
/// Создает файл конфигурации
/// </summary>
public class IniFile
{
    private static string path = Application.dataPath + "/inifile.ini";
 
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section,
        string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section,
             string key, string def, StringBuilder retVal,
        int size, string filePath);
 
    /// <summary>
    /// Записать данные в конфиг. файл
    /// </summary>
    /// <PARAM name="Section"></PARAM>
    /// Section name
    /// <PARAM name="Key"></PARAM>
    /// Key Name
    /// <PARAM name="Value"></PARAM>
    /// Value Name
    public void IniWriteValue(string Section, string Key, string Value)
    {
        WritePrivateProfileString(Section, Key, Value, path);
    }
 
    /// <summary>
    /// Прочесть данные из конфиг. файла
    /// </summary>
    /// <PARAM name="Section"></PARAM>
    /// <PARAM name="Key"></PARAM>
    /// <PARAM name="Path"></PARAM>
    /// <returns></returns>
    public string IniReadValue(string Section, string Key)
    {
        StringBuilder temp = new StringBuilder(255);
        //int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
        GetPrivateProfileString(Section, Key, "", temp, 255, path);
        return temp.ToString();
 
    }
}
 