using System.Xml.Serialization;

namespace SimpleMachine
{
    public partial class Form1 : Form
    {
        private float total = 0;
        private float enteredMoney = 0;
        private List<string> items = new();

        public Form1()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void btn_IceTea_Click(object sender, EventArgs e)
        {
            total += float.Parse((sender as Button).Text);
            Cash.Text = total.ToString();
            Recept_lstbx.Items.Add((sender as Button).Name);
        }

        private void birmanat_btn_Click(object sender, EventArgs e)
        {
            enteredMoney += float.Parse((sender as Button).Text);
            MoneyEntered.Text = enteredMoney.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recept_lstbx.Items.Clear();
            Cash.Text = "0";
            total = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recept_lstbx.Items.Remove(Recept_lstbx.SelectedItem);
        }

        private void MoneyEntered_TextChanged(object sender, EventArgs e)
        {
            if (MoneyEntered.Text == "0" || MoneyEntered.Text.StartsWith("-"))
            {
                MessageBox.Show("Wrong input!");
                MoneyEntered.Text = "";
            }

            if (MoneyEntered.Text != "")
                enteredMoney = float.Parse(MoneyEntered.Text);

            if (total > enteredMoney)
            {
                label3.Visible = true;
            }
            else
                label3.Visible = false;

        }

        private void x_Click(object sender, EventArgs e)
        {
            var xml = new XmlSerializer(typeof(List<string>));
            using FileStream fs = new(enteredMoney.ToString() + ".xml", FileMode.OpenOrCreate);

            foreach (var item in Recept_lstbx.Items)
            {
                items.Add(item.ToString());
            }
            xml.Serialize(fs, items);

            if (total > enteredMoney)
                MessageBox.Show("You have not enough money!");
            else
            {
                if (enteredMoney - total != 0)
                    MessageBox.Show($" {enteredMoney - total}");
                else
                    MessageBox.Show($"Thanks for shopping :)");
            }

            Recept_lstbx.Items.Clear();
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
            if (fs.CanRead == false)
                MessageBox.Show("Wrong input!");
            else
            {
                items = xml.Deserialize(fs) as List<string>;

                foreach (var item in items)
                {
                    Recept_lstbx.Items.Add(item);
                }
            }

        }

        private void Kitkat_Click(object sender, EventArgs e)
        {

        }
    }
}
