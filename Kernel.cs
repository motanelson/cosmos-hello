using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Point = Cosmos.System.Graphics.Point;
using Sys = Cosmos.System;
using Cosmos.HAL;
using Cosmos.Core.IOGroup;

namespace CosmosKernel1
{

    public class windowss
    {
        public int x = 0;
        public int y = 0;
        public int w = 0;
        public int h = 0;
        public Bitmap dc;
        public int colorss;
    }
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;
        int maxy;
        int maxx;
        int maxwins;

        int parts(int i,int t)
        {
            return i/t;
        }
        void drawWindows(windowss[] wins)
        {
            int n = 0;
            canvas.Clear(Color.Green);
            for (n = 0; n < wins.Length; n++)
            {
                canvas.DrawImage(wins[n].dc, new Point(wins[n].x, wins[n].y));
            }
            canvas.Display();
        }
        windowss createWindow(int x,int y,int w,int h,int colorss)
        {
            windowss windowsss = new windowss();
            windowsss.y = y;
            windowsss.x = x;
            windowsss.w = w;
            windowsss.h = h;
            windowsss.dc = createsbitmap((uint)windowsss.w,(uint) windowsss.h);
            windowsss.colorss = colorss;
            fills(windowsss.dc, windowsss.colorss);
            rets(windowsss.dc, 0, 0, (int)w - 1, (int)w - 1, 0);
            return windowsss;
        }
        void rets(Bitmap b, int x, int y, int x1, int y1, int colors)
        {

            hlines(b, x, y, x1, colors);
            hlines(b, x, y1, x1, colors);
            vlines(b, x, y, y1, colors);
            vlines(b, x1, y, y1, colors);


        }
        void boxs(Bitmap b, int x, int y,int x1, int y1, int colors)
        {
            int n = 0;
    

            if (y1>=y) {
                for (n = 0; n < y1 - y; n++)
                {
                    hlines(b,x, y + n, x1, colors);  
                }
            }
        }
        void vlines(Bitmap b, int x, int y, int y1, int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x < b.Width && y < b.Height && x > -1 && y > -1 && y1 < b.Height && y1 > -1 && y1 >= y)
            {
                for (n = 0; n < y1 - y; n++)
                {
                    bt[y * b.Width + x + (n* b.Width)] = colors;
                }
            }
        }
        void hlines(Bitmap b, int x, int y,int x1, int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x < b.Width && y < b.Height && x > -1 && y > -1 && x1 < b.Width && x1 > -1 && x1 >= x) {
                for (n = 0; n < x1 - x;n++)
                {
                    bt[y * b.Width + x+n] = colors;
                }
            }
        }
        void psets(Bitmap b,int x , int y,int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x< b.Width && y<b.Height && x>-1 && y>-1) bt[y*b.Width+x] = colors;
        }
        int colors(byte reds,byte greens ,byte blues) {
            return blues | greens << 8 | reds  <<16;
        }
        Bitmap createsbitmap(uint x, uint y)
        {
            Bitmap bitmap = new Bitmap(x, y, ColorDepth.ColorDepth32);
            return bitmap;
        }
        void fills(Bitmap b,int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            for (n = 0; n < b.Height * b.Width; n++) bt[n] = colors;
        }
        protected override void BeforeRun()
        {
            maxx = 640;
            maxy = 480;
            maxwins = 10;
            Console.WriteLine("start.");
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(maxx, maxy, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Green);
            Sys.MouseManager.ScreenHeight =(uint) maxy ;
            Sys.MouseManager.ScreenWidth =(uint) maxx ;

        }

        protected override void Run()
        {
            Pen pen = new Pen(Color.DarkGreen);
            int n = 0;
            int x = 0;
            int y = 0;
            int xx = maxx-1;
            int yy = maxy-1;
            windowss cursors= createWindow(0, 0, 1, 1, colors(0, (byte)parts(0xff, n), 0));
            Boolean  c1 = false;
           int c = new Pen(Color.Black).ValueARGB ;
            windowss[] windowsss = new windowss[maxwins];
        
            for (n=0;n< maxwins; n++) windowsss[n]=createWindow(n * 10 + 8, n * 10 + 8,100, 100,colors(0,(byte)parts(0xff,n),0));
             drawWindows(windowsss);

            x = (int)Sys.MouseManager.X;
            n =0;
            y = (int)Sys.MouseManager.Y;
            while (1==1)
            {
                x = (int)Sys.MouseManager.X;
                n = (int)Sys.MouseManager.MouseState;
                y = (int)Sys.MouseManager.Y;
                if (x!=xx || y!=yy) {
                    if (!c1)
                    {
                        xx = x;
                        yy = y;
                        c =canvas.GetPointColor(x, y).ToArgb();
                        c1 = true;
                    }
                    else 
                    {
                        psets(cursors.dc, 0, 0, c);
                        canvas.DrawImage(cursors.dc,new Point(xx, yy));
                        c = canvas.GetPointColor(x, y).ToArgb() ;
                        canvas.DrawPoint(new Pen(Color.White), new Point(x, y));
                        xx = x;
                        yy = y;

                        canvas.Display();
                        
                    }
                }

            }
            Console.ReadKey();
           
        }
    }
}
