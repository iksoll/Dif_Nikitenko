using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Accommodation> accommodations = new List<Accommodation>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        accommodations.Add(new Accommodation { Id = int.Parse(parts[0]), Name = parts[1], Price = decimal.Parse(parts[2]) });
                        listBox1.Items.Add($"Название: {parts[1]}, Цена:{parts[2]}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не найден");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sortBy = comboBox1.SelectedItem.ToString();

            var sortedList = sortBy == "Цена" ?
                             accommodations.OrderBy(a => a.Price) :
                             accommodations.OrderBy(a => a.Name);

            listBox1.Items.Clear();
            foreach (var accommodation in sortedList)
            {
                listBox1.Items.Add($"Название: {accommodation.Name}, Цена: {accommodation.Price}");
            }
        }

        public class Accommodation
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }


    }
}

