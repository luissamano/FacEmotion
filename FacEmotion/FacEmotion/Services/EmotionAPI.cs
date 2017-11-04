using Microsoft.ProjectOxford.Emotion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacEmotion.Services
{
    class EmotionAPI
    {
        static string key = "b0292528de1242aa976adaf8ffaee352";

        public static async Task<Dictionary<string, float>> ObtenerEmociones(Stream stream)
        {
            EmotionServiceClient cliente = new EmotionServiceClient(key);
            var emociones = await cliente.RecognizeAsync(stream);

            if (emociones == null || emociones.Count() == 0)
                return null;


            return emociones[0].Scores.ToRankedList().ToDictionary(x => x.Key, x => x.Value);

        }
    }
}
