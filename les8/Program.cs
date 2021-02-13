using System;  
using System.Configuration;  

namespace les8
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = ReadOrCreateSeting("UserName", "Введите свое имя:");
            var age = ReadOrCreateSeting("Age", "Введите свой возвраст:");
            var typeOfActivity = ReadOrCreateSeting("TypeOfActivity", "Введите свою сферу дейстельности:");
            
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Сфера деятельности: {typeOfActivity}");
        }

        /**
         * Читает параметр конфигурации, если его нет, то запрашивает
         */
        static string ReadOrCreateSeting(string key, string message)
        {
            var value = ReadSetting(key);
            if (value == null)
            {
                Console.WriteLine(message);
                value = Console.ReadLine();
                AddUpdateAppSettings(key, value);
            }

            return value;
        }
        
        /**
         * Читает параметр конфигурации
         */
        static string? ReadSetting(string key)  
        {  
            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  
                return appSettings[key];  
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error reading app settings");  
            }

            return null;
        }  

        /**
         * Записывает либо обновляет параметр конфигурации
         */
        static void AddUpdateAppSettings(string key, string value)  
        {  
            try  
            {  
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  
                var settings = configFile.AppSettings.Settings;  
                if (settings[key] == null)  
                {  
                    settings.Add(key, value);  
                }  
                else  
                {  
                    settings[key].Value = value;  
                }  
                configFile.Save(ConfigurationSaveMode.Modified);  
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);  
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error writing app settings");  
            }  
        }  
    }
}