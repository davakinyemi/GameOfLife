using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfLife
{
    class TemplateFile
    {
        public void load(string filePath, out Cell[,] area)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String widthString, heightString;

                    if ((widthString = sr.ReadLine()) == null || (heightString = sr.ReadLine()) == null)
                    {
                        throw new Exception("Invalid file format");
                    }

                    UInt32 width    = Convert.ToUInt32(widthString);
                    UInt32 height   = Convert.ToUInt32(heightString);
                    Cell[,] newArea = new Cell[width, height];

                    UInt32 numberOfCells = width * height;
                    UInt32 cellCounter   = 0;

                    String cellStatusString;
                    while ((cellStatusString = sr.ReadLine()) != null)
                    {
                        ++cellCounter;

                        UInt32 x = cellCounter % width;
                        UInt32 y = cellCounter/width;

                        Cell.Status status;
                        if (cellStatusString == "0")
                            status = Cell.Status.Empty;
                        else if (cellStatusString == "1")
                            status = Cell.Status.Alive;
                        else if (cellStatusString == "2")
                            status = Cell.Status.Dead;
                        else
                            throw new Exception("Invalid file format: Invalid cell status");

                        newArea[x, y] = new Cell(status, 0);
                    }

                    if (cellCounter != numberOfCells)
                        throw new Exception("Invalid file format: Not enough cells");

                    area = newArea;
                }
            }
            catch (Exception e)
            {
                area = null;
                throw e;
            }
        }

        public void save(string filePath, ref Cell[,] area)
        {
            var rank = area.Rank;

            if (rank != 2)
                throw new Exception("Not two dimensional");

            int height = area.GetUpperBound(1);
            int width  = area.GetLowerBound(2);

            try {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("%d", width);
                    sw.WriteLine("%d", height);

                    for (var i = 0; i < height; ++height)
                    {
                        for (var j = 0; j < width; ++width)
                        {
                            sw.WriteLine("%d", area[i, j].status);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

         }
    }
}
