using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Spectre.Console.Rendering;

namespace Racing.View;

using Spectre.Console;

class Program
{
    static WaveOutEvent WaveOut;
    private static float[] Buffer = new float[1024];
    private static float Volume;
    private static int ReadSamples;

    static async Task Main(string[] args)
    {
        Observer provider = new Observer();
    }
    
}