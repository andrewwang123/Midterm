using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// added system.io to implement filestream function
using System.IO;

namespace Midterm
{
    public partial class Form1 : Form
    {
        public int counter = 1;
        List<Panel> listPanel = new List<Panel>();
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            listPanel.Add(panel4);
            listPanel[0].BringToFront();

        }


        private StreamWriter streamWriter;
        private StreamWriter streamWriter2;
        private StreamReader streamReader;
        public enum TextBoxIndices { ID, Name, Price, Description }

        public string[] GetTextBoxValues()
        {
            return new string[]
            {
                productID.Text = Convert.ToString(counter),
                productName.Text,
                productPrice.Text,
                productDescription.Text

            };
        }

        public class FastFood
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int price { get; set; }
            public string Description { get; set; }
  


            public FastFood(int productID, string productName, int productPrice, string productDescription)
            {
                ID = productID;
                Name = productName;
                price = productPrice;
                Description = productDescription;
            }
        }

        
        public void ClearTextBoxes()
        {
            foreach (Control inControl in Controls)
            {
                (inControl as TextBox)?.Clear();
            }
        }

        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();

            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            
            if (result == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        streamWriter = new StreamWriter(output);
                        
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error opening file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] values = GetTextBoxValues();
            

            if (!string.IsNullOrEmpty(values[(int)TextBoxIndices.ID]))
            {
                try
                {
                    int productIDR = int.Parse(values[(int)TextBoxIndices.ID]);
                    int productPriceR = int.Parse(values[(int)TextBoxIndices.Price]);
                    if (productIDR > 0)
                    {
                        var fastfood = new FastFood(productIDR, values[(int)TextBoxIndices.Name], productPriceR, values[(int)TextBoxIndices.Description]);

                        streamWriter.WriteLine($"{fastfood.ID}, {fastfood.Name}, {fastfood.Description}, {fastfood.price}");
                        MessageBox.Show("You have successfully submitted an entry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Invalid ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error writing file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Format. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ClearTextBoxes();
            counter++;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }



        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            listPanel[2].BringToFront();

            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

           
            if (result == DialogResult.OK)
            {
                ClearTextBoxes();

                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        FileStream input = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

                        streamWriter = new StreamWriter(input);

                    
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void btnSaveNewOrder_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }


            if (result == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        streamWriter = new StreamWriter(output);

                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error opening file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            string[] values = GetTextBoxValues();


            if (!string.IsNullOrEmpty(values[(int)TextBoxIndices.ID]))
            {
                try
                {
                    int productIDR = int.Parse(values[(int)TextBoxIndices.ID]);
                    int productPriceR = int.Parse(values[(int)TextBoxIndices.Price]);
                    if (productIDR > 0)
                    {
                        var fastfood = new FastFood(productIDR, values[(int)TextBoxIndices.Name], productPriceR, values[(int)TextBoxIndices.Description]);

                        streamWriter2.WriteLine($"{fastfood.ID}, {fastfood.Name}, {fastfood.Description}, {fastfood.price}");
                        MessageBox.Show("You have successfully submitted an entry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Invalid ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error writing file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Format. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ClearTextBoxes();
            counter++;
        }


        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
        }

      

     

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            listPanel[3].BringToFront();

            var query = from s in GetTextBoxValues()
                        where s.Name== "Records"
                        select s;

            foreach (FastFood res in query)
            {
                lblResult.Text = (" ID: " + res.ID + ", Name: " + res.Name + ", Price: "
                                 + res.price + ", Description: " + res.Description  + Environment.NewLine);
            }
           
        }
    }
}
