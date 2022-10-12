using System.Xml.Serialization;

namespace Food_Machine
{
    public partial class Form1 : Form
    {
        private float total = 0;
        private float enteredMoney = 0;
        private List<string> items = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_IceTea_Click(object sender, EventArgs e)
        {
            total += float.Parse((sender as Button).Text);
            Cash.Text = total.ToString();
            Recept.Items.Add((sender as Button).Name);
        }

        private void birmanat_btn_Click(object sender, EventArgs e)
        {
            enteredMoney += float.Parse((sender as Button).Text);
            MoneyEntered.Text = enteredMoney.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recept.Items.Clear();
            Cash.Text = "0";
            total = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recept.Items.Remove(Recept.SelectedItem);
        }

        private void MoneyEntered_TextChanged(object sender, EventArgs e)
        {
            if (MoneyEntered.Text == "0" || MoneyEntered.Text.StartsWith("-"))
            {
                MessageBox.Show("Tekrar cehd edin. Daxil etdiyiniz sehvdir");
                MoneyEntered.Text = "";
            }

            if (MoneyEntered.Text != "")
                enteredMoney = float.Parse(MoneyEntered.Text);

        }

        private void x_Click(object sender, EventArgs e)
        {
            var xml = new XmlSerializer(typeof(List<string>));
            using FileStream fs = new(enteredMoney.ToString() + ".xml", FileMode.OpenOrCreate);

            foreach (var item in Recept.Items)
            {
                items.Add(item.ToString());
            }
            xml.Serialize(fs, items);

            if (total > enteredMoney)
                MessageBox.Show("Kifayet qeder vesait yoxdur");
            else
            {
                if (enteredMoney - total != 0)
                    MessageBox.Show($"Qaliq {enteredMoney - total}");
                else
                    MessageBox.Show($"Yene gozleyirik:)");
            }

            Recept.Items.Clear();
            total = 0;
            enteredMoney = 0;
            MoneyEntered.Text = "";
            Cash.Text = "";
            items.Clear();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var xml = new XmlSerializer(typeof(List<string>));
            using FileStream fs = new(LoadRecept_txt.Text + ".xml", FileMode.Open);
       

        }


    }
}