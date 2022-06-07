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
using System.Text.Json;

namespace QuizFojcik
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Model.Quiz q = new Model.Quiz();

        private int selected_Id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_question.Text == "" || textBox_A.Text == "" || textBox_B.Text == ""
                || textBox_C.Text == "" || textBox_D.Text == "")
            {
                MessageBox.Show("Pola nie mągą być puste");
            }
            else if (chckBox_A.IsChecked == false && chckBox_B.IsChecked == false
                && chckBox_C.IsChecked == false && chckBox_D.IsChecked == false)
            {
                MessageBox.Show("Przynajmniej jedna odpowiedź musi być poprawna");
            }
            else
            {
                Model.Pytanie p = new Model.Pytanie();

                p.tresc = textBox_question.Text;

                Model.Odpowiedz o1 = new Model.Odpowiedz();
                o1.tresc = textBox_A.Text;
                if (chckBox_A.IsChecked == true)
                    o1.poprawnosc = true;
                else
                    o1.poprawnosc = false;
                p.odpowiedzi.Add(o1);

                Model.Odpowiedz o2 = new Model.Odpowiedz();
                o2.tresc = textBox_B.Text;
                if (chckBox_B.IsChecked == true)
                    o2.poprawnosc = true;
                else
                    o2.poprawnosc = false;
                p.odpowiedzi.Add(o2);

                Model.Odpowiedz o3 = new Model.Odpowiedz();
                o3.tresc = textBox_C.Text;
                if (chckBox_C.IsChecked == true)
                    o3.poprawnosc = true;
                else
                    o3.poprawnosc = false;
                p.odpowiedzi.Add(o3);

                Model.Odpowiedz o4 = new Model.Odpowiedz();
                o4.tresc = textBox_D.Text;
                if (chckBox_D.IsChecked == true)
                    o4.poprawnosc = true;
                else
                    o4.poprawnosc = false;
                p.odpowiedzi.Add(o4);

                q.zbiorPytan.Add(p);

                listbox_question.Items.Add(p.ToString());


                textBox_question.Text = "";
                textBox_A.Text = "";
                textBox_B.Text = "";
                textBox_C.Text = "";
                textBox_D.Text = "";
                chckBox_A.IsChecked = false;
                chckBox_B.IsChecked = false;
                chckBox_C.IsChecked = false;
                chckBox_D.IsChecked = false;
            }

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int id = listbox_question.SelectedIndex;
            if (listbox_question.SelectedIndex != -1)
            {
                listbox_question.Items.RemoveAt(id);
            }
            q.zbiorPytan.RemoveAt(id);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_tytul.Text == "")
            {
                MessageBox.Show("Wybierz tytuł quizu");

            }
            else if (q.zbiorPytan.Count() == 0)
            {
                MessageBox.Show("W quizie musi być chociaż jedno pytanie");
            }
            else
            {
                string path = "C:/quiz/";
                q.tytul = textBox_tytul.Text;
                if (Directory.Exists(path))
                {
                    save(path);
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    save(path);
                }
                MessageBox.Show("Quiz został zapisany");
            }
        }

        private void save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path + q.tytul + ".json"))
            {
                string text = new Model.JSONSerializer<Model.Quiz>().Serialize(q);
                text = new Model.Cezar().Encode(text);
                sw.WriteLine(text);
                sw.Close();
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            selected_Id = listbox_question.SelectedIndex;
            int id = listbox_question.SelectedIndex;
            if (listbox_question.SelectedIndex != -1)
            {
                Model.Pytanie p = new Model.Pytanie();
                p = q.zbiorPytan[id];

                textBox_question.Text = p.tresc;
                textBox_A.Text = p.odpowiedzi[0].tresc;
                textBox_B.Text = p.odpowiedzi[1].tresc;
                textBox_C.Text = p.odpowiedzi[2].tresc;
                textBox_D.Text = p.odpowiedzi[3].tresc;

                if (p.odpowiedzi[0].poprawnosc)
                {
                    chckBox_A.IsChecked = true;
                }
                if (p.odpowiedzi[1].poprawnosc)
                {
                    chckBox_B.IsChecked = true;
                }
                if (p.odpowiedzi[2].poprawnosc)
                {
                    chckBox_C.IsChecked = true;
                }
                if (p.odpowiedzi[3].poprawnosc)
                {
                    chckBox_D.IsChecked = true;
                }
                btn_Add.Visibility = Visibility.Hidden;
                btn_Delete.Visibility = Visibility.Hidden;
                btn_Edit.Visibility = Visibility.Hidden;
                btn_Save_Edit.Visibility = Visibility.Visible;
            }
        }

        private void btn_Save_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_question.Text == "" || textBox_A.Text == "" || textBox_B.Text == ""
                || textBox_C.Text == "" || textBox_D.Text == "")
            {
                MessageBox.Show("Pola nie mągą być puste");
            }
            else if (chckBox_A.IsChecked == false && chckBox_B.IsChecked == false
                && chckBox_C.IsChecked == false && chckBox_D.IsChecked == false)
            {
                MessageBox.Show("Przynajmniej jedna odpowiedź musi być poprawna");
            }
            else
            {
                Model.Pytanie p = new Model.Pytanie();

                p.tresc = textBox_question.Text;

                Model.Odpowiedz o1 = new Model.Odpowiedz();
                o1.tresc = textBox_A.Text;
                if (chckBox_A.IsChecked == true)
                    o1.poprawnosc = true;
                else
                    o1.poprawnosc = false;
                p.odpowiedzi.Add(o1);

                Model.Odpowiedz o2 = new Model.Odpowiedz();
                o2.tresc = textBox_B.Text;
                if (chckBox_B.IsChecked == true)
                    o2.poprawnosc = true;
                else
                    o2.poprawnosc = false;
                p.odpowiedzi.Add(o2);

                Model.Odpowiedz o3 = new Model.Odpowiedz();
                o3.tresc = textBox_C.Text;
                if (chckBox_C.IsChecked == true)
                    o3.poprawnosc = true;
                else
                    o3.poprawnosc = false;
                p.odpowiedzi.Add(o3);

                Model.Odpowiedz o4 = new Model.Odpowiedz();
                o4.tresc = textBox_D.Text;
                if (chckBox_D.IsChecked == true)
                    o4.poprawnosc = true;
                else
                    o4.poprawnosc = false;
                p.odpowiedzi.Add(o4);

                listbox_question.Items[selected_Id] = p.ToString();
                q.zbiorPytan[selected_Id] = p;

                textBox_question.Text = "";
                textBox_A.Text = "";
                textBox_B.Text = "";
                textBox_C.Text = "";
                textBox_D.Text = "";
                chckBox_A.IsChecked = false;
                chckBox_B.IsChecked = false;
                chckBox_C.IsChecked = false;
                chckBox_D.IsChecked = false;

                btn_Add.Visibility = Visibility.Visible;
                btn_Delete.Visibility = Visibility.Visible;
                btn_Edit.Visibility = Visibility.Visible;
                btn_Save_Edit.Visibility = Visibility.Hidden;
            }
        }
    }
}