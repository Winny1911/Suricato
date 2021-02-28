using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Suricato.Persistence
{
    public static class Data
    {
        private const string curren_user_local_data = "curren_user_local_data";
        private const string licence_local_data = "licence_local_data";
        private const string users_local_data = "users_local_data";        

        private static ISettings AppPersistentData
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static Model.Licence.ResponseLicence LicenceLocalData
        {
            get
            {
                var licence_data = AppPersistentData.GetValueOrDefault(licence_local_data, "");

                if (!string.IsNullOrEmpty(licence_data))
                    return new Wrappers.JsonToModel().ConvertJsonToModel<Model.Licence.ResponseLicence>(licence_data);
                else
                    return null;
            }
            set
            {

                if (value != null)
                {
                    var dados_licenca = JsonConvert.SerializeObject(value);
                    AppPersistentData.AddOrUpdateValue(licence_local_data, dados_licenca);
                }
                else
                {
                    DeleteLicenceLocalData();
                }
            }
        }

        public static List<Model.Account> UsersLocalData
        {
            get
            {
                var users_data = AppPersistentData.GetValueOrDefault(users_local_data, "");

                if (!string.IsNullOrEmpty(users_local_data))
                    return new Wrappers.JsonToModel().ConvertJsonToModel<List<Model.Account>>(users_data);
                else
                    return null;
            }
            set
            {

                if (value != null)
                {
                    var users_data = JsonConvert.SerializeObject(value);
                    AppPersistentData.AddOrUpdateValue(users_local_data, users_data);
                }
                else
                {
                    DeleteUsersLocalData();
                }
            }
        }

        public static Model.User CurrentUserLocalData
        {
            get
            {
                var user_data = AppPersistentData.GetValueOrDefault(curren_user_local_data, "");

                if (!string.IsNullOrEmpty(user_data))
                    return new Wrappers.JsonToModel().ConvertJsonToModel<Model.User>(user_data);
                else
                    return null;
            }
            set
            {

                if (value != null)
                {
                    var user = JsonConvert.SerializeObject(value);
                    AppPersistentData.AddOrUpdateValue(curren_user_local_data, user);
                }
                else
                {
                    DeleteCurrentUserLocalData();
                }
            }
        }

        //remove methods

        private static void DeleteLicenceLocalData()
        {
            try
            {
                AppPersistentData.AddOrUpdateValue(licence_local_data, "");
            }
            catch (System.Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static void DeleteCurrentUserLocalData()
        {
            try
            {
                AppPersistentData.AddOrUpdateValue(curren_user_local_data, "");
            }
            catch (System.Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static void DeleteUsersLocalData()
        {
            try
            {
                AppPersistentData.AddOrUpdateValue(users_local_data, "");
            }
            catch (System.Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
