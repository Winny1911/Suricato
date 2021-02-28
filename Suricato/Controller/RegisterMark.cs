using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Suricato.Controller
{
    public class RegisterMark
    {
        public ImageSource GetLastBase64MarkRegister()
        {
            ImageSource FotoRegistroPonto;
            Model.TimeClockPointment register = new Model.TimeClockPointment();

            try
            {
                //if (Persistence.Data.CurrentUserLocalData.registroponto != null && Persistence.Data.CurrentUserLocalData.RegistrosPonto.Count > 0)
                //    register = Persistence.Data.CurrentUserLocalData.RegistrosPonto.First(); //.OrderByDescending(p => p.).First();

                //if (register != null && !string.IsNullOrEmpty(register.Foto)){
                //    FotoRegistroPonto = new Helpers.Media().Base64ToImage(register.Foto);
                //    return FotoRegistroPonto;
                //}
                //else
                //{
                //    throw new Exception(AppResource.ImagemRegistroNaoEncontrado);
                //}


            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
            }

            return null;

        }

    //    public void AddRegisterMark(MediaFile File)
    //    {
    //        Model.User user = new Model.User();
    //        List<Model.MarkRegister> registers =new List<Model.MarkRegister>();


    //        try
    //        {
    //            Model.MarkRegister register = new Model.MarkRegister()
    //            {
    //                Id = Guid.NewGuid(),
    //                PhotoBase64 = new Helpers.Media().BynaryToBase64Image(File.GetStream()),
    //                RegisterDate = DateTime.Now,
    //                UserId = Persistence.Data.CurrentUserID
    //            };

    //            registers.Add(register);

    //            user = Persistence.Data.UserStorage;
    //            user.MarkRegisters = registers;
    //            Persistence.Data.UserStorage = user;

    //        }
    //        catch (Exception err)
    //        {
    //            Console.WriteLine(err.Message);
    //        }
    //    }
   }
}
