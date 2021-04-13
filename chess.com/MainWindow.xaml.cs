using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace chess.com
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    
                    var bor = new Button();
                    bor.Click += Active;
                    bor.Height = 100;
                    bor.Width = 100;
                    bor.Background = Brushes.Yellow;
                    
                    count += 1;
                    if ((count) % 2 == 0) 
                    { 
                        bor.Background = Brushes.Red; 
                    }
                    Grid.SetRow(bor, i);
                    Grid.SetColumn(bor, j);
                    
                    stack.Children.Add(bor);
                    

                }
                count += 1;
            }
            Cell(0, 0); Cell(0, 1); Cell(0, 2); Cell(0, 3); Cell(0, 4); Cell(0, 5); Cell(0, 6); Cell(0, 7);
            Cell(1, 0); Cell(1, 1); Cell(1, 2); Cell(1, 3); Cell(1, 4); Cell(1, 5); Cell(1, 6); Cell(1, 7);
            Cell(2, 0); Cell(2, 1); Cell(2, 2); Cell(2, 3); Cell(2, 4); Cell(2, 5); Cell(2, 6); Cell(2, 7);
            Cell(3, 0); Cell(3, 1); Cell(3, 2); Cell(3, 3); Cell(3, 4); Cell(3, 5); Cell(3, 6); Cell(3, 7);
            Cell(4, 0); Cell(4, 1); Cell(4, 2); Cell(4, 3); Cell(4, 4); Cell(4, 5); Cell(4, 6); Cell(4, 7);
            Cell(5, 0); Cell(5, 1); Cell(5, 2); Cell(5, 3); Cell(5, 4); Cell(5, 5); Cell(5, 6); Cell(5, 7);
            Cell(6, 0); Cell(6, 1); Cell(6, 2); Cell(6, 3); Cell(6, 4); Cell(6, 5); Cell(6, 6); Cell(6, 7);
            Cell(7, 0); Cell(7, 1); Cell(7, 2); Cell(7, 3); Cell(7, 4); Cell(7, 5); Cell(7, 6); Cell(7, 7);
        }
        public static string[,] figures = new string[8, 8]
        {
            {"чладья","чконь","чслон","чферзь","чкороль","чслон","чконь","чладья" },
            {"чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка" },
            {null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null},
            {"бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка" },
            {"бладья","бконь","бслон","бферзь","бкороль","бслон","бконь","бладья" },

        };
        public void Cell(int i,int j)
        {
            //класс для расстановки фигур
            Image img = new Image();
            img.Height = 100;
            img.Width = 100;
            img.MouseDown += Active;
            
                    string name = figures[i, j];
                    if (name == "чпешка")
                    {
                        img.Name = "чпешка";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/чпешка.png"));
                    }
                    if (name == "бпешка")
                    {
                        img.Name = "бпешка";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бпешка.png"));
                    }
                    if (name == "бконь")
                    {
                        img.Name = "бконь";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бконь.png"));
                    }
                    if (name == "чконь")
                    {
                        img.Name = "чконь";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/чконь.jpg"));
                    }
                    if (name == "бслон")
                    {
                        img.Name = "бслон";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бслон.jpg"));
                    }
                    if (name == "чслон")
                    {
                        img.Name = "чслон";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/чслон.jpeg"));
                    }
                    if (name == "бладья")
                    {
                        img.Name = "бладья";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бладья.jpg"));
                    }
                    if (name == "чладья")
                    {
                        img.Name = "чладья";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/чладья.jpg"));
                    }
                    if (name == "бкороль")
                    {
                        img.Name = "бкороль";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бкороль.jpeg"));
                    }
                    if (name == "чкороль")
                    {
                        img.Name = "чкороль";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/чкороль.jpg"));
                    }
                    if (name == "бферзь")
                    {
                        img.Name = "бферзь";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бферзь.jpeg"));
                    }
                    if (name == "чферзь")
                    {
                        img.Name = "чферзь";
                        img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/чферзь.jpg"));
                    }
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    stack.Children.Add(img);
                    
        }
        public static bool flag = false;//переменная для проверки второго нажатия на клетку
        public static object figure;
        public static object figure2;
        private void Active(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                firstpos = sender;
                rules(figure,firstpos);
                if(sender is Image && mogno) 
                { var ii = sender as Image;
                    
                    int column = Grid.GetColumn(ii);
                    int row = Grid.GetRow(ii);
                    stack.Children.Remove(ii);
                    
                    var figurecopy = figure as Image;
                    string name = figurecopy.Name;
                    var figuredelete = figure as Image;
                    stack.Children.Remove(figuredelete);
                    if (bferz) 
                    {
                        figurecopy.Source= new BitmapImage(new System.Uri("pack://application:,,,/Resources/бферзь.jpeg"));
                        Grid.SetColumn(figurecopy, column);
                        Grid.SetRow(figurecopy, row);
                        stack.Children.Add(figurecopy);
                        bferz = false;
                    }
                    else 
                    {
                        Grid.SetColumn(figurecopy, column);
                        Grid.SetRow(figurecopy, row);
                        stack.Children.Add(figurecopy);
                    }
                    forbor();
                }
                if(sender is Button && mogno)
                { var ii = sender as Button;
                    var figurecopy = figure as Image;
                    int row = Grid.GetRow(ii);
                    int column = Grid.GetColumn(ii);
                    var figuredelete = figure as Image;
                    stack.Children.Remove(figuredelete);
                    if (bferz)
                    {
                        figurecopy.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/бферзь.jpeg"));
                        Grid.SetColumn(figurecopy, column);
                        Grid.SetRow(figurecopy, row);
                        stack.Children.Add(figurecopy);
                        bferz = false;
                    }
                    else
                    {
                        Grid.SetColumn(figurecopy, column);
                        Grid.SetRow(figurecopy, row);
                        stack.Children.Add(figurecopy);
                    }
                    forbor();
                }
                
                flag = false;
                forbor();
            }
            else {
                if (sender is Image) 
                {
                    
                    ActiveSecond(sender); 
                } 
            }
            
        }
        public static object bor1;
        public static object firstpos;
        public static bool bferz;
        public void forfigure()
        {
            var figure1 = figure as Image;
            stack.Children.Remove(figure1);
        }
        public void forbor()
        {
            var bor11 = bor1 as Button;
            stack.Children.Remove(bor11);
        }
        public void ActiveSecond(object sender)
        {
                var ii = sender as Image;
                string iiname = ii.Name;
                var source = ii.Source;
                int row = Grid.GetRow(ii);
                int column = Grid.GetColumn(ii);
                var bor = new Button();
                bor.Height = 100;

                bor.Name = "delete";
                bor.Click += Active;
                bor.Width = 100;
                bor.BorderThickness = new Thickness(5);
                bor.Background = new SolidColorBrush(Colors.White) { Opacity = 0 };
                bor.BorderBrush = new SolidColorBrush(Colors.Blue);
                bor1 = bor;
                stack.Children.Remove(ii);
                Image img = new Image();
                img.Source = source;
                img.Name = iiname;
                img.MouseDown += Active;
                img.Height = 100;
                img.Width = 100;
                
                figure = img;
                Grid.SetRow(bor, row);
                Grid.SetColumn(bor, column);
                Grid.SetRow(img, row);
                Grid.SetColumn(img, column);
                stack.Children.Add(bor);
                stack.Children.Add(img);
            flag = true;
        }
        public void transport(object sender)
        {
            
            
        }
        public static bool mogno;
        public static bool forferz;
        public void rules(object sender, object secondsender)
        {
            var figurerules = sender as Image;
            var button=new Button();
            var image = new Image();
            if (secondsender is Image) 
            {
                image = secondsender as Image;
                if (figurerules.Name == "бферзь")
                {
                    int x = Grid.GetRow(figurerules);//ширина
                    int y = Grid.GetColumn(figurerules);//высота начиная сверху
                    int x2 = Grid.GetRow(image);
                    int y2 = Grid.GetColumn(image);
                    mogno = false;
                    int x3 = x2 - x;
                    int y3 = y2 - y;
                    int xcopy = x;
                    if (x3 > 0 && y==y2) //если x3 больше нуля значит я переместил фигуру вправо и не меняя высоту 
                    {
                        int count = 0;
                            while (xcopy != x2)
                            {
                                xcopy += 1;//надо вычитать если фигура перемещается влево
                                if (figures[xcopy, y] != null)
                                {
                                count += 1;
                                }
                            }
                        if (count == 0)
                        {
                            if (x == x2 || y == y2 || x3 == y3 || x3 == y3 * (-1))
                            {
                                figurerules.Name = "бферзь";
                                figures[x, y] = null;
                                figures[x2, y2] = "бферзь";
                                mogno = true;
                            }
                        }
                    }
                    if (y3 > 0)
                    {

                    }
                    else 
                    { 

                    }
                    
                }
                if (figurerules.Name == "бпешка" || figurerules.Name == "бпешка2")
                {
                    int x = Grid.GetRow(figurerules);
                    int y = Grid.GetColumn(figurerules);
                    int x2 = Grid.GetRow(image);
                    int y2 = Grid.GetColumn(image);
                    mogno = false;
                    if (x - 1 == x2 && (y + 1 == y2 || y - 1 == y2))
                    {
                        figures[x, y] = null;
                        figures[x2, y2] = "бпешка";
                        mogno = true;
                        if (x2 == 0)
                        {
                            figurerules.Name = "бферзь";
                            figures[x, y] = null;
                            figures[x2, y2] = "бферзь";
                            bferz = true;
                        }
                    }

                }
            }
            if (secondsender is Button)
            {
                button = secondsender as Button;
                if (figurerules.Name == "бпешка"|| figurerules.Name == "бпешка2")
                {
                    int x = Grid.GetRow(figurerules);
                    int y = Grid.GetColumn(figurerules);
                    int x2 = Grid.GetRow(button);
                    int y2 = Grid.GetColumn(button);
                    if (figurerules.Name == "бпешка2")
                    {

                        if (x - 1 == x2 && y == y2)
                        {
                            figures[x, y] = null;
                            figures[x2, y2] = "бпешка";
                            mogno = true;
                            if (x2 == 0)
                            {
                                figurerules.Name = "бферзь";
                                figures[x, y] = null;
                                figures[x2, y2] = "бферзь";
                                bferz = true;
                            }
                        }
                        else
                        {
                            mogno = false;
                        }
                    }
                    if (figurerules.Name == "бпешка")
                    {
                        if ((x - 1 == x2 && y == y2) || (x - 2 == x2 && y == y2))
                        {
                            mogno = true;
                            figures[x, y] = null;
                            figures[x2, y2] = "бпешка";
                            figurerules.Name = "бпешка2";
                        }
                        else
                        {
                            mogno = false;
                        }
                    }

                }
            }

            
        }
    }


}



