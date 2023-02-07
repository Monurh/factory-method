using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    abstract class Car
    {
        public abstract void OpenDoors();
        public abstract void TurnOnHeadlights();
    }

    class Honda : Car
    {
        public override void OpenDoors()
        {
            MessageBox.Show("Двері Хонди відчинилися");
        }

        public override void TurnOnHeadlights()
        {
            MessageBox.Show("Фари Хонди увімкнені");
        }
    }

    class BMW : Car
    {
        public override void OpenDoors()
        {
            MessageBox.Show("Двері БМВ відкриті");
        }

        public override void TurnOnHeadlights()
        {
            MessageBox.Show("Фари БМВ увімкнені");
        }
    }

    class Mercedes : Car
    {
        public override void OpenDoors()
        {
            MessageBox.Show("Двері Мерседеса відкриті");
        }

        public override void TurnOnHeadlights()
        {
            MessageBox.Show("Фари Мерседеса увімкнені");
        }
    }

    class CarFactory
    {
        public static Car CreateCar(string type)
        {
            switch (type)
            {
                case "Хонда":
                    return new Honda();
                case "БМВ":
                    return new BMW();
                case "Мерседес":
                    return new Mercedes();
                default:
                    return null;
            }
        }
    }

    class CarForm : Form
    {
        private ComboBox carComboBox;
        private Button createButton;

        public CarForm()
        {
            this.carComboBox = new ComboBox();
            this.carComboBox.Items.AddRange(new object[] { "Хонда", "БМВ", "Мерседес" });
            this.carComboBox.Location = new Point(10, 10);
            this.Controls.Add(this.carComboBox);

            this.createButton = new Button();
            this.createButton.Text = "Створення авто";
            this.createButton.Location = new Point(10, 40);
            this.createButton.Click += new EventHandler(this.CreateButton_Click);
            this.Controls.Add(this.createButton);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.carComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть марку авто");
                return;
            }

            string carBrand = this.carComboBox.SelectedItem.ToString();
            Car car = CarFactory.CreateCar(carBrand);
            if (car == null)
            {
                MessageBox.Show("Не вірна марка");
                return;
            }

            MessageBox.Show("Створеня авто");
            car.OpenDoors();
            car.TurnOnHeadlights();
        }
    }
}
