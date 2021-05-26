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


//庫存程式V0.1
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string Path = ".\\intxt\\Stock.txt";
        
        public MainWindow()
        {
            InitializeComponent();
            string[] content = File.ReadAllText(Path).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);//拿到文本所有內容，存在一個數組中
            for (int i = 1; i <= 70; i++)
            {
                ((TextBox)this.FindName("T" + i)).Text = content[i - 1].ToString();//將文本的內容賦值給TextBox,因爲我們一個四條數據，所以i<=4.
            }
        }
        //"更新庫存按鈕"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] t = new int[71];
            int[] o = new int[71];
            int[] i = new int[71];
            int[] r = new int[71];

            for (int x = 1; x < 71; x++)
            {
                Int32.TryParse(((TextBox)this.FindName("T" + x)).Text, out i[x]);
                Int32.TryParse(((TextBox)this.FindName("O" + x)).Text, out o[x]);
                Int32.TryParse(((TextBox)this.FindName("I" + x)).Text, out t[x]);
                Int32.TryParse(((TextBox)this.FindName("T" + x)).Text, out r[x]);

                ((TextBox)this.FindName("T" + x)).Text = ((t[x] + i[x] - o[x]).ToString());
                ((TextBox)this.FindName("O" + x)).Text = ((0).ToString());
                ((TextBox)this.FindName("I" + x)).Text = ((0).ToString());
                if (r[x] <= 0) 
                {
                    MessageBox.Show((((Label)this.FindName("item" + x)).Content,((Label)this.FindName("N" + x)).Content)+"庫存不足,請注意", "錯誤");
                }
            }
        }   
        //"存檔按鈕"
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] content = File.ReadAllText(Path).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i <= 70; i++)
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
    }
}