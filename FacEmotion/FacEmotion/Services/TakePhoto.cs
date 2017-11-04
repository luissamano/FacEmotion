using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacEmotion.Services
{
    class TakePhoto
    {
        public static async Task<MediaFile> TomarFoto(bool usarCamara)
        {
            await CrossMedia.Current.Initialize();
            if (usarCamara)
            {
                if (!CrossMedia.Current.IsCameraAvailable ||
                    !CrossMedia.Current.IsTakePhotoSupported)
                {
                    return null;
                }
            }

            var file = usarCamara ? await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "CognitiveServices",
                Name = "img.jpg"
            }) :

            await CrossMedia.Current.PickPhotoAsync();


            return file;
        }
    }
}
