using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MonoWasmDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Image<Rgba32> image = new Image<Rgba32>(100,100);
            Console.WriteLine("Hello from C#! {0}x{1}", image.Width, image.Height);
        }
    }
}
