using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random;
        public double X { get; set; }
        public double Y { get; set; }
        public int BulletUpdate { get; set; }
        public int InvaderUpdate { get; set; }
        public bool Moving { get; set; }

        public MainWindow()
        {         
            InitializeComponent();
            random = new Random();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            spaceShip.SetValue(Canvas.BottomProperty, Y);
            
            X = 0;
            Y = 0;
            
            BulletUpdate = 0;
            InvaderUpdate = 0;
            Moving = true;

            invader1.SetValue(Canvas.LeftProperty, 64.0*2);
            invader2.SetValue(Canvas.LeftProperty, 64.0*3);
            invader3.SetValue(Canvas.LeftProperty, 64.0*4);
            invader4.SetValue(Canvas.LeftProperty, 64.0*5);
            invader5.SetValue(Canvas.LeftProperty, 64.0*6);
            invader6.SetValue(Canvas.LeftProperty, 64.0*7);
            
            invader1.SetValue(Canvas.TopProperty,0.0);
            invader2.SetValue(Canvas.TopProperty, 0.0);
            invader3.SetValue(Canvas.TopProperty, 0.0);
            invader4.SetValue(Canvas.TopProperty, 0.0);
            invader5.SetValue(Canvas.TopProperty, 0.0);
            invader6.SetValue(Canvas.TopProperty, 0.0);

        }
        void CompositionTarget_Rendering(object sender, System.EventArgs e)
        {
            spaceShip.SetValue(Canvas.LeftProperty, X);
            InvaderUpdater();
            
            if (BulletUpdate > 10)
            {

                if (theCanvas.Children.Count > 7)
                {
                    for (int i = 7; i < theCanvas.Children.Count; i++)
                    {
                        double possition = (double)theCanvas.Children[i].GetValue(Canvas.BottomProperty);
                        theCanvas.Children[i].SetValue(Canvas.BottomProperty, possition + 20);
                    }
                    
                }
                BulletUpdate = 0;
            }
            BulletUpdate++;
            InvaderUpdate++;
            
        }

        private void theEllipse_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.D)
            {
                X += 10;
            }
            if (e.Key == Key.A)
            {
                X -= 10;
            }
        }

        private void theEllipse_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Space)
            {

                Rectangle rec = new Rectangle()
                {
                    Width = 5,
                    Height = 20,
                    Fill = Brushes.Black,                    
                };

                // Add to a canvas 
                theCanvas.Children.Add(rec);
                Canvas.SetBottom(theCanvas.Children[theCanvas.Children.Count-1], Y+50);
                Canvas.SetLeft(theCanvas.Children[theCanvas.Children.Count-1], X+25);

            }

        }
        private void InvaderUpdater()
        {
            if (InvaderUpdate > 5)
            {

                if (Moving)
                {
                    //move right
                    invader1.SetValue(Canvas.LeftProperty, 5 + (double)invader1.GetValue(Canvas.LeftProperty));
                    invader2.SetValue(Canvas.LeftProperty, 5 + (double)invader2.GetValue(Canvas.LeftProperty));
                    invader3.SetValue(Canvas.LeftProperty, 5 + (double)invader3.GetValue(Canvas.LeftProperty));
                    invader4.SetValue(Canvas.LeftProperty, 5 + (double)invader4.GetValue(Canvas.LeftProperty));
                    invader5.SetValue(Canvas.LeftProperty, 5 + (double)invader5.GetValue(Canvas.LeftProperty));
                    invader6.SetValue(Canvas.LeftProperty, 5 + (double)invader6.GetValue(Canvas.LeftProperty));
                    InvaderUpdate = 0;
                }
                else
                {
                    //move left
                    invader1.SetValue(Canvas.LeftProperty, (double)invader1.GetValue(Canvas.LeftProperty) - 5);
                    invader2.SetValue(Canvas.LeftProperty, (double)invader2.GetValue(Canvas.LeftProperty) - 5);
                    invader3.SetValue(Canvas.LeftProperty, (double)invader3.GetValue(Canvas.LeftProperty) - 5);
                    invader4.SetValue(Canvas.LeftProperty, (double)invader4.GetValue(Canvas.LeftProperty) - 5);
                    invader5.SetValue(Canvas.LeftProperty, (double)invader5.GetValue(Canvas.LeftProperty) - 5);
                    invader6.SetValue(Canvas.LeftProperty, (double)invader6.GetValue(Canvas.LeftProperty) - 5);
                    InvaderUpdate = 0;
                }

                if (Moving)
                {
                    // select juiste invader nog 
                    double lastinvaderRight = (double)invader6.GetValue(Canvas.LeftProperty) + 64;
                    if (lastinvaderRight >= 798)
                    {
                        invader1.SetValue(Canvas.LeftProperty, (double)invader1.GetValue(Canvas.LeftProperty) - 10);
                        invader2.SetValue(Canvas.LeftProperty, (double)invader2.GetValue(Canvas.LeftProperty) - 10);
                        invader3.SetValue(Canvas.LeftProperty, (double)invader3.GetValue(Canvas.LeftProperty) - 10);
                        invader4.SetValue(Canvas.LeftProperty, (double)invader4.GetValue(Canvas.LeftProperty) - 10);
                        invader5.SetValue(Canvas.LeftProperty, (double)invader5.GetValue(Canvas.LeftProperty) - 10);
                        invader6.SetValue(Canvas.LeftProperty, (double)invader6.GetValue(Canvas.LeftProperty) - 10);

                        invader1.SetValue(Canvas.TopProperty, (double)invader1.GetValue(Canvas.TopProperty) + 10);
                        invader2.SetValue(Canvas.TopProperty, (double)invader2.GetValue(Canvas.TopProperty) + 10);
                        invader3.SetValue(Canvas.TopProperty, (double)invader3.GetValue(Canvas.TopProperty) + 10);
                        invader4.SetValue(Canvas.TopProperty, (double)invader4.GetValue(Canvas.TopProperty) + 10);
                        invader5.SetValue(Canvas.TopProperty, (double)invader5.GetValue(Canvas.TopProperty) + 10);
                        invader6.SetValue(Canvas.TopProperty, (double)invader6.GetValue(Canvas.TopProperty) + 10);
                        Moving = false;
                    }
                }
                else
                {
                    // select juiste invader nog 
                    double lastinvaderLeft = (double)invader1.GetValue(Canvas.LeftProperty);
                    if (lastinvaderLeft <= 0)
                    {
                        invader1.SetValue(Canvas.LeftProperty, (double)invader1.GetValue(Canvas.LeftProperty) + 10);
                        invader2.SetValue(Canvas.LeftProperty, (double)invader2.GetValue(Canvas.LeftProperty) + 10);
                        invader3.SetValue(Canvas.LeftProperty, (double)invader3.GetValue(Canvas.LeftProperty) + 10);
                        invader4.SetValue(Canvas.LeftProperty, (double)invader4.GetValue(Canvas.LeftProperty) + 10);
                        invader5.SetValue(Canvas.LeftProperty, (double)invader5.GetValue(Canvas.LeftProperty) + 10);
                        invader6.SetValue(Canvas.LeftProperty, (double)invader6.GetValue(Canvas.LeftProperty) + 10);

                        invader1.SetValue(Canvas.TopProperty, (double)invader1.GetValue(Canvas.TopProperty) + 10);
                        invader2.SetValue(Canvas.TopProperty, (double)invader2.GetValue(Canvas.TopProperty) + 10);
                        invader3.SetValue(Canvas.TopProperty, (double)invader3.GetValue(Canvas.TopProperty) + 10);
                        invader4.SetValue(Canvas.TopProperty, (double)invader4.GetValue(Canvas.TopProperty) + 10);
                        invader5.SetValue(Canvas.TopProperty, (double)invader5.GetValue(Canvas.TopProperty) + 10);
                        invader6.SetValue(Canvas.TopProperty, (double)invader6.GetValue(Canvas.TopProperty) + 10);
                        Moving = true;
                    }
                }

            }
        }
    }
}
