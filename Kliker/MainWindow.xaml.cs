using System;
using System.Reflection;
using System.IO;
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


namespace Kliker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool clicked;
        player player = new player();
        obiekt obiekt1 = new obiekt(0, 1, 100, "Kursor");
        obiekt obiekt2 = new obiekt(0, 40, 2000, "Pani Grażynka");
        obiekt obiekt3 = new obiekt(0, 600, 30000, "Botnet");
        obiekt obiekt4 = new obiekt(0, 8000, 400000, "Bardzo dużo małp");

        public MainWindow()
        {
            InitializeComponent();
            enablecheck();
            obiekt1_Name.Content = obiekt1.Name;
            Obiekt2_Name.Content = obiekt2.Name;
            Obiekt3_Name.Content = obiekt3.Name;
            Obiekt4_Name.Content = obiekt4.Name;
            designupdate();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        } 

        private void click_Click(object sender, RoutedEventArgs e)
        {
            help.Visibility = System.Windows.Visibility.Collapsed;
            help2.Visibility = System.Windows.Visibility.Collapsed;
            help3.Visibility = System.Windows.Visibility.Collapsed;
            if (!MainWindow.clicked)
            {
                clickanimation1();
            }
            else
            {
                clickanimation2();
            }
            player.addcliks(upgradeslist.upgradadditionalcpc);
            designupdate();
        }
        void designupdate()
        {
            x.Content = string.Format("Kliknięte {0} razy", player.Cliks.ToString());
            y.Content = string.Format(" {0} kliknięć na sekunde", player.Clikspersecound.ToString());
        }
        public void clickanimation1()
        {
            Thickness t = new Thickness();
            t.Left = 200;
            t.Top = 117;
            click.Margin = t;
            click.Height = 200;
            click.Width = 200;
            MainWindow.clicked = true;
        }
       public void clickanimation2()
        {
            Thickness t = new Thickness();
            t.Left = 225;
            t.Top = 117;
            click.Margin = t;
            click.Height = 150;
            click.Width = 150;
            MainWindow.clicked = false;
        }
       private void Tick(object sender, EventArgs e)
       {
           for (int x = 1; x <= 30; x++)
           {
               enablecheck();
               designupdate();
           }
           player.addcliks(player.Clikspersecound);
       }

       private void o1_1_Click(object sender, RoutedEventArgs e)
       {
           obiekt1.add(player, 1);
           designupdate();
       }

       private void o1_10_Click(object sender, RoutedEventArgs e)
       {
           obiekt1.add(player, 10);
           designupdate();
       }

       private void o1_100_Click(object sender, RoutedEventArgs e)
       {
           obiekt1.add(player, 100);
           designupdate();
       }
       private void o2_1_Click(object senderm, RoutedEventArgs e)
       {
           obiekt2.add(player, 1);
           designupdate();
       }

       private void save_Click(object sender, RoutedEventArgs e)
       {
           string path = Environment.CurrentDirectory + "/save.txt";
           if (File.Exists(path))
           {
               File.Delete(path);
           }
           string s = "/";
           StreamWriter file = new StreamWriter(path);
           double _control = ((Math.Round(player.Cliks + obiekt1.Amount + obiekt2.Amount + obiekt3.Amount + obiekt4.Amount, 0) * 3) + 7);
           file.WriteLine(player.Cliks + s + obiekt1.Amount + s + obiekt2.Amount + s + obiekt3.Amount + s + obiekt4.Amount + s + _control + s + upgradeslist.Upgradelist[0].IsActive + s + upgradeslist.Upgradelist[1].IsActive + s + upgradeslist.Upgradelist[2].IsActive + s + upgradeslist.Upgradelist[3].IsActive + s + upgradeslist.Upgradelist[4].IsActive + s + upgradeslist.Upgradelist[5].IsActive + s + upgradeslist.Upgradelist[6].IsActive + s + upgradeslist.Upgradelist[7].IsActive);
           file.Close();
       }
       private void load_Click(object sender, RoutedEventArgs e)
       {
           try
           {
               string path = Environment.CurrentDirectory + "/save.txt";
               StreamReader file = new StreamReader(path);
               string[] load = file.ReadLine().Split('/');
               double _control = ((Math.Round(Convert.ToDouble(load[0]) + Convert.ToDouble(load[1]) + Convert.ToDouble(load[2]) + Convert.ToDouble(load[3]) + Convert.ToDouble(load[4]), 0) * 3) + 7);
               if (Convert.ToInt16(load[5]) == _control)
               {
                   player.setCliks(Convert.ToDouble(load[0]));
                   obiekt1.setAmount(Convert.ToInt16(load[1]));
                   obiekt2.setAmount(Convert.ToInt16(load[2]));
                   obiekt3.setAmount(Convert.ToInt16(load[3]));
                   obiekt4.setAmount(Convert.ToInt16(load[4]));
                   if (load[6] == "1") 
                   {
                       upgradeslist.Upgradelist[0].setActive();
                       u1_1_cliked = true;
                   }
                   if (load[7] == "1")
                   {
                       upgradeslist.Upgradelist[1].setActive();
                       u1_2_cliked = true;
                   }
                   if (load[8] == "1")
                   {
                       upgradeslist.Upgradelist[2].setActive();
                       u1_3_cliked = true;
                   }
                   if (load[9] == "1")
                   {
                       upgradeslist.Upgradelist[3].setActive();
                       u1_4_cliked = true;
                   }
                   if (load[10] == "1")
                   {
                       upgradeslist.Upgradelist[4].setActive();
                       u2_1_cliked = true;
                   }
                   if (load[11] == "1")
                   {
                       upgradeslist.Upgradelist[5].setActive();
                       u2_2_cliked = true;
                   }
                   if (load[12] == "1")
                   {
                       upgradeslist.Upgradelist[6].setActive();
                       u2_3_cliked = true;
                   }
                   if (load[13] == "1")
                   {
                       upgradeslist.Upgradelist[7].setActive();
                       u2_4_cliked = true;
                   }
               }
               else
               {
                   MessageBox.Show("Plik zapisu jest edytowany w niedozwolony sposób lub uszkodzony, zostanie on usunięty");
                   File.Delete(path);
               }
           }
           catch
           {
               MessageBox.Show("Błąd odczytu: Brak pliku zapisu w folderze, lub inny problem");
           }
       }

       private void o2_10_Click(object sender, RoutedEventArgs e)
       {
           obiekt2.add(player, 10);
           designupdate();
       }

       private void o2_100_Click(object sender, RoutedEventArgs e)
       {
           obiekt2.add(player, 100);
           designupdate();
       }

       private void o3_1_Click(object sender, RoutedEventArgs e)
       {
           obiekt3.add(player, 1);
           designupdate();
       }

       private void o3_10_Click(object sender, RoutedEventArgs e)
       {
           obiekt3.add(player, 10);
           designupdate();
       }

       private void o3_100_Click(object sender, RoutedEventArgs e)
       {
           obiekt3.add(player, 100);
           designupdate();
       }

       private void o4_1_Click(object sender, RoutedEventArgs e)
       {
           obiekt4.add(player, 1);
           designupdate();
       }

       private void o4_10_Click(object sender, RoutedEventArgs e)
       {
           obiekt4.add(player, 10);
           designupdate();
       }

       private void o4_100_Click(object sender, RoutedEventArgs e)
       {
           obiekt4.add(player, 100);
           designupdate();
       }

       bool u1_1_cliked;
       bool u1_2_cliked;
       bool u1_3_cliked;
       bool u1_4_cliked;
       bool u2_1_cliked;
       bool u2_2_cliked;
       bool u2_3_cliked;
       bool u2_4_cliked;
       
       void enablecheck() 
       {
           o1_1.ToolTip = obiekt1.dprice(1);
           o1_10.ToolTip = obiekt1.dprice(10);
           o1_100.ToolTip = obiekt1.dprice(100);
           o2_1.ToolTip = obiekt2.dprice(1);
           o2_10.ToolTip = obiekt2.dprice(10);
           o2_100.ToolTip = obiekt2.dprice(100);
           o3_1.ToolTip = obiekt3.dprice(1);
           o3_10.ToolTip = obiekt3.dprice(10);
           o3_100.ToolTip = obiekt3.dprice(100);
           o4_1.ToolTip = obiekt4.dprice(1);
           o4_10.ToolTip = obiekt4.dprice(10);
           o4_100.ToolTip = obiekt4.dprice(100);
           u1_1.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[0].cost);
           u1_2.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[1].cost);
           u1_3.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[2].cost);
           u1_4.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[3].cost);
           u2_1.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[4].cost);
           u2_2.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[5].cost);
           u2_3.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[6].cost);
           u2_4.ToolTip = string.Format("Koszt: {0} klików", upgradeslist.Upgradelist[7].cost);
           if (player.Cliks < upgradeslist.Upgradelist[0].cost || u1_1_cliked == true)
           {
               u1_1.IsEnabled = false;
           }
           else { u1_1.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[1].cost || u1_2_cliked == true)
           {
               u1_2.IsEnabled = false;
           }
           else { u1_2.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[2].cost || u1_3_cliked == true)
           {
               u1_3.IsEnabled = false;
           }
           else { u1_3.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[3].cost || u1_4_cliked == true)
           {
               u1_4.IsEnabled = false;
           }
           else { u1_4.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[4].cost || u2_1_cliked == true)
           {
               u2_1.IsEnabled = false;
           }
           else { u2_1.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[5].cost || u2_2_cliked == true)
           {
               u2_2.IsEnabled = false;
           }
           else { u2_2.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[6].cost || u2_3_cliked == true)
           {
               u2_3.IsEnabled = false;
           }
           else { u2_3.IsEnabled = true; }
           if (player.Cliks < upgradeslist.Upgradelist[7].cost || u2_4_cliked == true)
           {
               u2_4.IsEnabled = false;
           }
           else { u2_4.IsEnabled = true; }
           if(player.Cliks < obiekt1.Dprice(1)){
               o1_1.IsEnabled = false;
           }
           else { o1_1.IsEnabled = true; }
           if (player.Cliks < obiekt1.Dprice(10))
           {
               o1_10.IsEnabled = false;
           }
           else { o1_10.IsEnabled = true; }
           if (player.Cliks < obiekt1.Dprice(100))
           {
               o1_100.IsEnabled = false;
           }
           else { o1_100.IsEnabled = true; }
           if (player.Cliks < obiekt2.Dprice(1))
           {
               o2_1.IsEnabled = false;
           }
           else { o2_1.IsEnabled = true; }
           if (player.Cliks < obiekt2.Dprice(10))
           {
               o2_10.IsEnabled = false;
           }
           else { o2_10.IsEnabled = true; }
           if (player.Cliks < obiekt2.Dprice(100))
           {
               o2_100.IsEnabled = false;
           }
           else { o2_100.IsEnabled = true; }
           if (player.Cliks < obiekt3.Dprice(1))
           {
               o3_1.IsEnabled = false;
           }
           else { o3_1.IsEnabled = true; }
           if (player.Cliks < obiekt3.Dprice(10))
           {
               o3_10.IsEnabled = false;
           }
           else { o3_10.IsEnabled = true; }
           if (player.Cliks < obiekt3.Dprice(100))
           {
               o3_100.IsEnabled = false;
           }
           else { o2_100.IsEnabled = true; }
           if (player.Cliks < obiekt4.Dprice(1))
           {
               o4_1.IsEnabled = false;
           }
           else { o4_1.IsEnabled = true; }
           if (player.Cliks < obiekt4.Dprice(10))
           {
               o4_10.IsEnabled = false;
           }
           else { o4_10.IsEnabled = true; }
           if (player.Cliks < obiekt4.Dprice(100))
           {
               o4_100.IsEnabled = false;
           }
           else { o4_100.IsEnabled = true; }
       }

       private void music_Click(object sender, RoutedEventArgs e)
       {

       }

       private void u1_1_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[0].setActive();
           u1_1_cliked = true;
           player.pay(upgradeslist.Upgradelist[0].cost);
       }

       private void u1_2_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[1].setActive();
           u1_2_cliked = true;
           player.pay(upgradeslist.Upgradelist[1].cost);
       }

       private void u1_3_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[2].setActive();
           u1_3_cliked = true;
           player.pay(upgradeslist.Upgradelist[2].cost);
       }

       private void u1_4_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[3].setActive();
           u1_4_cliked = true;
           player.pay(upgradeslist.Upgradelist[3].cost);
       }

       private void u2_1_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[4].setActive();
           u2_1_cliked = true;
           player.pay(upgradeslist.Upgradelist[4].cost);
       }
       private void u2_2_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[5].setActive();
           u2_2_cliked = true;
           player.pay(upgradeslist.Upgradelist[5].cost);
       }

       private void u2_3_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[6].setActive();
           u2_3_cliked = true;
           player.pay(upgradeslist.Upgradelist[6].cost);
       }

       private void u2_4_Click(object sender, RoutedEventArgs e)
       {
           upgradeslist.Upgradelist[7].setActive();
           u2_4_cliked = true;
           player.pay(upgradeslist.Upgradelist[7].cost);
       }

   }
}
