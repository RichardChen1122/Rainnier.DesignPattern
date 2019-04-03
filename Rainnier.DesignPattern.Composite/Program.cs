using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFile folder1 = new Folder("EDC");
            AbstractFile folder2 = new Folder("ImageFile");
            AbstractFile folder3 = new Folder("TextFile");
            AbstractFile folder4 = new Folder("Vedio");

            AbstractFile image1 = new ImageFile("xiao.jpg");
            AbstractFile image2 = new ImageFile("da.gif");

            AbstractFile text1 = new TextFile("t.txt");
            AbstractFile text2 = new TextFile("d.doc");

            AbstractFile video1 = new VideoFile("x.rmvb");
            AbstractFile video2 = new VideoFile("l.mp4");

            folder2.Add(image1);
            folder2.Add(image2);

            folder3.Add(text1);
            folder3.Add(text2);

            folder4.Add(video1);
            folder4.Add(video2);

            folder1.Add(folder2);
            folder1.Add(folder3);
            folder1.Add(folder4);

            //folder1.KillVirus();

            folder3.KillVirus();

            Console.ReadKey();
        }
    }
}
