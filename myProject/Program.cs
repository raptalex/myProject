// Alexander Raptis, Feb 6th 2023

using System;

namespace myProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Collect all color types into one comma separated string
            string colorTypesStr = string.Join(", ", Enum.GetNames(typeof(Image.ColorType)));
            
            // Creating object with default constructor
            Image image1 = new Image();
            image1.SetWidth(1920);
            image1.SetHeight(1080);
            image1.SetColorType(1); // Testing overload of int -> enum

            // Creating object with default constructor and user input
            Image image2 = new Image();
            Console.Write("Enter the width of the image: ");
            image2.SetWidth(int.Parse(Console.ReadLine()));
            Console.Write("Enter the height of the image: ");
            image2.SetHeight(int.Parse(Console.ReadLine()));

            Console.Write($"Enter the colortype ({colorTypesStr}): ");

            // Parse string into enum value
            Enum.TryParse(Console.ReadLine(), out Image.ColorType myColorType);
            image2.SetColorType(myColorType);

            // Creating object with parameterized constructor
            Image image3 = new Image(512, 512, Image.ColorType.PALETTE);

            // Creating object with parameterized constructor and user input
            Console.Write("Enter the width of the image: ");
            int tempWidth = int.Parse(Console.ReadLine());
            Console.Write("Enter the height of the image: ");
            int tempHeight = int.Parse(Console.ReadLine());

            Console.Write($"Enter the colortype ({colorTypesStr}): ");
            // Parse string into enum value
            Enum.TryParse(Console.ReadLine(), out Image.ColorType tempColorType);

            Image image4 = new Image(tempWidth, tempHeight, tempColorType);

            ShowImageInfo(image1);
            ShowImageInfo(image2);
            ShowImageInfo(image3);
            ShowImageInfo(image4);
        }
        public static void ShowImageInfo(Image img)
        {
            Console.WriteLine("This image has the following dimensions:");
            Console.WriteLine($"Width: {img.GetWidth()}");
            Console.WriteLine($"Height: {img.GetHeight()}");
            Console.WriteLine($"It has the following colorcode: {img.GetColorType().ToString()}");
        }
    }

    class Image
    {
        // Class containing information about a raster image
        // minus the actual pixel data

        // Color types a raster image could have
        public enum ColorType
        {
            RGBA,
            RGB,
            GREYSCALE,
            PALETTE
        }

        private int _width;
        private int _height;
        private ColorType _colorType;

        public Image()
        {
            _width = 0;
            _height = 0;
            _colorType = ColorType.RGBA;
        }
        public Image(int width, int height, ColorType ctype = ColorType.RGBA)
        {
            _width = width;
            _height = height;
            _colorType = ctype;
        }
        public int GetWidth()
        {
            return _width;
        }
        public int GetHeight()
        {
            return _height;
        }
        public ColorType GetColorType()
        {
            return _colorType;
        }
        public void SetWidth(int width)
        {
            _width = width;
        }
        public void SetHeight(int height)
        {
            _height = height;
        }
        public void SetColorType(ColorType ctype)
        {
            _colorType = ctype;
        }
        public void SetColorType(int ctype)
        {
            _colorType = (ColorType)ctype;
        }
    }
}