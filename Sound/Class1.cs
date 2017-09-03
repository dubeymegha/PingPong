using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sound
{
    public class Class1
    {
        public static void go()
        {
            System.Media.SoundPlayer mysp = new System.Media.SoundPlayer(@"C:\Users\megu\Documents\hola_mamam_wav.wav");
            mysp.Play();
        }
        public static void stop()
        {
            System.Media.SoundPlayer mysp = new System.Media.SoundPlayer(@"C:\Users\megu\Documents\hola_mamam_wav.wav");
            mysp.Stop();
        }
    }
}
