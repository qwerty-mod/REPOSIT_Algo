using System;
using System.Collections.Generic;

class ImageCompressor
{
    private int[,] _pixels;
    private readonly List<string> _output = new List<string>();
    private readonly Queue<ImageRegion> _regionsToProcess = new Queue<ImageRegion>();

    public void Run(string inputFile)
    {
        LoadImage(inputFile);
        ProcessImage();
        PrintResult();
    }

    private void LoadImage(string filePath)
    {
        var lines = System.IO.File.ReadAllLines(filePath);
        var size = lines[0].Split();
        int width = int.Parse(size[0]), height = int.Parse(size[1]);

        _pixels = new int[height, width];
        for (int row = 0; row < height; row++)
        {
            var values = lines[row + 1].Split();
            for (int col = 0; col < width; col++)
                _pixels[row, col] = int.Parse(values[col]);
        }
    }

    private void ProcessImage()
    {
        var firstRegion = new ImageRegion(0, 0, _pixels.GetLength(1), _pixels.GetLength(0));
        _output.Add($"{firstRegion.Width} {firstRegion.Height}");

        if (IsSolidColor(firstRegion))
        {
            _output.Add(_pixels[0, 0].ToString());
        }
        else
        {
            _output.Add("Z");
            _regionsToProcess.Enqueue(firstRegion);

            while (_regionsToProcess.Count > 0)
            {
                var current = _regionsToProcess.Dequeue();
                _output.Add(SplitRegion(current));
            }
        }
    }

    private string SplitRegion(ImageRegion region)
    {
        var parts = new string[4];
        var subRegions = region.Split();

        for (int i = 0; i < 4; i++)
        {
            parts[i] = ProcessSubRegion(subRegions[i]);
        }

        return string.Join(" ", parts);
    }

    private string ProcessSubRegion(ImageRegion subRegion)
    {
        if (subRegion.IsEmpty) return "-";
        if (IsSolidColor(subRegion)) return _pixels[subRegion.Top, subRegion.Left].ToString();

        _regionsToProcess.Enqueue(subRegion);
        return "Z";
    }

    private bool IsSolidColor(ImageRegion region)
    {
        int color = _pixels[region.Top, region.Left];
        for (int row = region.Top; row < region.Bottom; row++)
        {
            for (int col = region.Left; col < region.Right; col++)
            {
                if (_pixels[row, col] != color)
                    return false;
            }
        }
        return true;
    }

    private void PrintResult()
    {
        foreach (var line in _output)
        {
            Console.WriteLine(line);
        }
    }
}

struct ImageRegion
{
    public int Left { get; }
    public int Top { get; }
    public int Width { get; }
    public int Height { get; }
    public int Right => Left + Width;
    public int Bottom => Top + Height;
    public bool IsEmpty => Width <= 0 || Height <= 0;

    public ImageRegion(int left, int top, int width, int height)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    public ImageRegion[] Split()
    {
        int halfWidth = Width / 2;
        int halfHeight = Height / 2;
        int remainingWidth = Width - halfWidth;
        int remainingHeight = Height - halfHeight;

        return new[]
        {
            new ImageRegion(Left, Top, remainingWidth, remainingHeight),
            new ImageRegion(Left + remainingWidth, Top, halfWidth, remainingHeight),
            new ImageRegion(Left, Top + remainingHeight, remainingWidth, halfHeight),
            new ImageRegion(Left + remainingWidth, Top + remainingHeight, halfWidth, halfHeight)
        };
    }
}

class Program
{
    static void Main()
    {
        var compressor = new ImageCompressor();
        compressor.Run("C:\\Users\\user\\Desktop\\input.txt");
    }
}