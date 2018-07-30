using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace qms.Utility
{
    public class AudioManager
    {
        //public static bool TextToMP3(string text, int branch_id)
        //{
        //    //try
            //{
                //        GoogleCredential credentials = GoogleCredential.FromFile(Path.Combine(HttpContext.Current.Server.MapPath("~"), "SmartQueue-c6126eb496a7.json"));

                //        TextToSpeechClient client = TextToSpeechClient.Create(credentials);

                //        SynthesizeSpeechResponse response = client.SynthesizeSpeech(
                //            new SynthesisInput()
                //            {
                //                Text = text
                //            },
                //            new VoiceSelectionParams()
                //            {
                //                LanguageCode = "en-US",
                //                Name = "en-US-Wavenet-C"
                //            },
                //            new AudioConfig()
                //            {
                //                AudioEncoding = AudioEncoding.Mp3
                //            }
                //        );
                //        string fileName = branch_id.ToString() + ".mp3";
                //        string speechFile = Path.Combine(HttpContext.Current.Server.MapPath("~/Voices"), fileName);

                //        System.IO.File.WriteAllBytes(speechFile, response.AudioContent);
                //        return true;
                //    }
                //    catch (Exception)
                //    {
                //        throw;
                //    }
                //}
                 }
            }
            