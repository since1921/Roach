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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string Path = @"C:\Users\user\source\repos\WinFormsApp3\bin\Debug\net5.0-windows\intxt\Stock.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        //"更新庫存按鈕"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
                T1.Text = Convert.ToString(Convert.ToInt32(T1.Text) + Convert.ToInt32(I1.Text) - Convert.ToInt32(O1.Text));
                T2.Text = Convert.ToString(Convert.ToInt32(T1.Text) + Convert.ToInt32(I2.Text) - Convert.ToInt32(O2.Text));
                T3.Text = Convert.ToString(Convert.ToInt32(T1.Text) + Convert.ToInt32(I3.Text) - Convert.ToInt32(O3.Text));
                T4.Text = Convert.ToString(Convert.ToInt32(T1.Text) + Convert.ToInt32(I4.Text) - Convert.ToInt32(O4.Text));
                T5.Text = Convert.ToString(Convert.ToInt32(T1.Text) + Convert.ToInt32(I5.Text) - Convert.ToInt32(O5.Text));
                MessageBox.Show("更新完成","提示");
            }catch
            {
                MessageBox.Show("更新失敗,請確認", "提示");
            }
            */

            int t1, t2, t3, t4, t5;
            int i1, i2, i3, i4, i5;
            int o1, o2, o3, o4, o5;
            if (Int32.TryParse(I1.Text, out i1) && Int32.TryParse(O1.Text, out o1) && Int32.TryParse(T1.Text, out t1))
            {
                T1.Text = ((t1 + i1 - o1).ToString());
                O1.Text = "0";
                I1.Text = "0";


                if (Int32.TryParse(I2.Text, out i2) && Int32.TryParse(O2.Text, out o2) && Int32.TryParse(T2.Text, out t2))
                {
                    T2.Text = ((t2 + i2 - o2).ToString());
                    O2.Text = "0";
                    I2.Text = "0";
                    
                }
                if (Int32.TryParse(I3.Text, out i3) && Int32.TryParse(O3.Text, out o3) && Int32.TryParse(T3.Text, out t3))
                {
                    T3.Text = ((t3 + i3 - o3).ToString());
                    O3.Text = "0";
                    I3.Text = "0";
                    ;
                }
                if (Int32.TryParse(I4.Text, out i4) && Int32.TryParse(O4.Text, out o4) && Int32.TryParse(T4.Text, out t4))
                {
                    T4.Text = ((t4 + i4 - o4).ToString());
                    O4.Text = "0";
                    I4.Text = "0";
                }
                if (Int32.TryParse(I5.Text, out i5) && Int32.TryParse(O5.Text, out o5) && Int32.TryParse(T5.Text, out t5))
                {
                    T5.Text = ((t5 + i5 - o5).ToString());
                    O5.Text = "0";
                    I5.Text = "0";
                }

                else
                {
                    MessageBox.Show("輸入的數值有誤", "提示");
                }
               
            }
            if (Int32.TryParse(T5.Text, out t5) && t5 <= 0)
            {
                    MessageBox.Show(N5.Content + "庫存不足", "錯誤");
            }
            if (Int32.TryParse(T4.Text, out t4) && t4 <= 0)
            {
                MessageBox.Show(N4.Content + "庫存不足", "錯誤");
            }
            if (Int32.TryParse(T3.Text, out t3) && t3 <= 0)
            {
                MessageBox.Show(N3.Content + "庫存不足", "錯誤");
            }
            if (Int32.TryParse(T2.Text, out t2) && t2 <= 0)
            {
                MessageBox.Show(N2.Content + "庫存不足", "錯誤");
            }
            if ((Int32.TryParse(T1.Text, out t1)) && t1 <= 0)
            {
                MessageBox.Show(N1.Content + "庫存不足", "錯誤");
            }
        }

        //"存檔按鈕"
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] content = File.ReadAllText(Path).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i <= 5; i++)
                {
                    //((TextBox)this.FindName("T" + i)).Text = content[i-1].ToString();
                    content[i - 1] = ((TextBox)this.FindName("T" + i)).Text;
                }
                System.IO.File.WriteAllText(Path, string.Join("\r\n", content));
                MessageBox.Show("儲存完成", "完成");
            }
            catch
            {
                MessageBox.Show("儲存失敗", "錯誤");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] content = File.ReadAllText(Path).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);//拿到文本所有內容，存在一個數組中
                for (int i = 1; i <= 5; i++)
                {
                    ((TextBox)this.FindName("T" + i)).Text = content[i - 1].ToString();//將文本的內容賦值給TextBox,因爲我們一個四條數據，所以i<=4.
                }
                MessageBox.Show("讀取成功", "完成");
            }
            catch
            {
                MessageBox.Show("讀取失敗,資料缺失", "錯誤");
            }
        }
    }
}
