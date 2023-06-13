using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace parking_system_c
{
    public partial class Form1 : Form
    {
        ParkingTicket[] assignedSpotList = new ParkingTicket[10];
        List<Button> buttons = new List<Button>();
        Timer timer = new Timer();

        int currentSpot = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            string time = "";
            string data = "";

            if (h < 10) time += "0" + h;
            else time += h;
            time += ":";

            if (m < 10) time += "0" + m;
            else time += m;
            time += ":";

            if (s < 10) time += "0" + s;
            else time += s;

            if (day < 10) data += "0" + day;
            else data += day;

            data += ".";
            if (month < 10) data += "0" + month;
            else data += month;

            data += ".";
            data += year;

            timeLable.Text = time;
            dateLabel.Text = data;
        }

        public void Inform()
        {
            string res = Util.TicketText(assignedSpotList);
            MessageBox.Show(res, "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetButtonRed(int i)
        {
            buttons[i].BackColor = Color.OrangeRed;
        }
        public void SetButtonGreen(int i)
        {
            buttons[i].BackColor = Color.SpringGreen;
        }
        public void HideButtons()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
        public void ShowButtons()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        public Form1()
        {
            InitializeComponent();
            buttons.Add(spot1);
            buttons.Add(spot2);
            buttons.Add(spot3);
            buttons.Add(spot4);
            buttons.Add(spot5);
            buttons.Add(spot6);
            buttons.Add(spot7);
            buttons.Add(spot8);
            buttons.Add(spot9);
            buttons.Add(spot10);
            panel1.Location = new Point(322, 43);
            panel2.Location = new Point(352, 43);
            Logger.Log("\n" + DateTime.Now.ToString() + ": NEW SESSION, ALL SPOTS ARE AVAILABLE\n-----------------------------------\n");
        }

        // panel1
        private void Button1_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            currentSpot = ParkingSpot.GetAvailableSpot(assignedSpotList);
            if (currentSpot == -1)
            {
                MessageBox.Show("Нет свободных парковочных мест!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                HideButtons();
                panel1.Visible = true;
            }
        }
        private void ButtonRandom_Click(object sender, EventArgs e)
        {
            textBox1.Text = Randomizer.NumberPlate();
            textBox2.Text = Randomizer.CarType();
            textBox3.Text = Randomizer.CarColor();
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 & textBox2.Text.Length != 0 & textBox3.Text.Length != 0)
            {
                if (Util.CheckNumberFormat(textBox1.Text))
                {
                    ParkingTicket parkingTicket = new ParkingTicket(
                        new Car(textBox1.Text, textBox2.Text, textBox3.Text), 
                        TimeUtil.GetDate(), 
                        currentSpot
                        );

                    assignedSpotList[currentSpot] = parkingTicket;

                    if (checkBox1.Checked)
                    {
                        Logger.Log(Logger.LoggerText(parkingTicket, "parked"));
                    }

                    SetButtonRed(currentSpot);
                    panel1.Visible = false;
                    ShowButtons();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    checkBox1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Неверный формат номера авто!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ButtonCancel1_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = true;
            panel1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            ShowButtons();
            currentSpot = -1;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            if (!ParkingSpot.CheckCarOnPark(assignedSpotList))
            {
                MessageBox.Show("На парковке отсутствуют автомобили!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                comboBox1.Items.Clear();
                foreach (ParkingTicket item in assignedSpotList)
                {
                    if (item != null)
                    {
                        comboBox1.Items.Add(item.Car.NumberPlate);
                    }
                }
                HideButtons(); 
                panel2.Visible = true;
            }
        }
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            int spot = 0;

            foreach (ParkingTicket pt in assignedSpotList)
            {
                if (pt != null)
                {
                    if (pt.Car.NumberPlate.Equals(comboBox1.SelectedItem))
                    {
                        DateTime enter = assignedSpotList[spot].EnterDataTime;
                        DateTime exit = TimeUtil.GetDate();
                       
                        int total = TimeUtil.GetTotalTime(enter, exit);
                        double amount = Payment.TotalAmount(total);
                       
                        string msg = Util.ExitText(assignedSpotList[spot], enter, exit, total, amount);
                        MessageBox.Show(msg, "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (checkBox1.Checked)
                        {
                            Logger.Log(Logger.LoggerText(assignedSpotList[spot], "removed"));
                        }

                        assignedSpotList[spot] = null;
                        panel2.Visible = false;
                        comboBox1.ResetText();
                        ShowButtons();
                        checkBox1.Visible = true;
                        SetButtonGreen(spot);
                        break;
                    }
                }
                spot++;
            }
        }
        private void ButtonCancel2_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = true;
            panel2.Visible = false;
            comboBox1.ResetText();
            ShowButtons();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Inform();
        }
    }
}
