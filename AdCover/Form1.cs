using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Media;
using System.Windows.Forms;


namespace AdCover
{
    public partial class Form1 : Form
    {
        bool timerPauseWasClicked = true;
        public Image myimage;
        private bool OpenFileButtonWasClicked = false;
        int hour;
        int minute;
        int second;
        SoundPlayer player;
        ContextMenu cm;
        Form1 parent = null;
        List<Form1> forms = new List<Form1>() { };
        int count = 0;

        public Form1()
        {
            InitializeComponent();
            this.parent = this;
            this.Name = "AdCover";
            CreateContextMenu();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public Form1(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            CreateContextMenu();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// 
        private void CreateContextMenu()
        {
            try
            {
                cm = new ContextMenu();
                MenuItem setColorItem = new MenuItem("Set Color");
                setColorItem.Click += ColorDialog;
                cm.MenuItems.Add(setColorItem);

                MenuItem setImageItem = new MenuItem("Set Image");
                cm.MenuItems.Add(setImageItem);

                MenuItem addImageItem = new MenuItem("Add Image");
                setImageItem.MenuItems.Add(addImageItem);
                addImageItem.Click += AddImage;

                MenuItem saveItem = new MenuItem("Save");
                setImageItem.MenuItems.Add(saveItem);
                saveItem.Click += SaveImg;

                MenuItem duplicateItem = new MenuItem("Duplicate");
                cm.MenuItems.Add(duplicateItem);

                MenuItem defaultItem = new MenuItem("Default");
                duplicateItem.MenuItems.Add(defaultItem);
                defaultItem.Click += CreateDefaultForm;

                MenuItem originalItem = new MenuItem("Original");
                duplicateItem.MenuItems.Add(originalItem);
                originalItem.Click += CreateOriginalForm;

                MenuItem timeItem = new MenuItem("Add Clock");
                cm.MenuItems.Add(timeItem);

                MenuItem hourMinItem = new MenuItem("hh:mm");
                timeItem.MenuItems.Add(hourMinItem);
                hourMinItem.Click += AddClock;

                MenuItem hourMinSecItem = new MenuItem("hh:mm:ss");
                timeItem.MenuItems.Add(hourMinSecItem);
                hourMinSecItem.Click += AddClockSec;

                MenuItem timerItem = new MenuItem("Timer");
                cm.MenuItems.Add(timerItem);

                MenuItem timeStartItem = new MenuItem("Start");
                timerItem.MenuItems.Add(timeStartItem);
                timeStartItem.Click += TimerStart;

                if (timerPauseWasClicked == true)
                {
                    MenuItem timePauseItem = new MenuItem("Pause");
                    timerItem.MenuItems.Add(timePauseItem);
                    timePauseItem.Click += TimerPause;
                    timerPauseWasClicked = false;
                }

                else
                {
                    MenuItem timerResumeItem = new MenuItem("Resume");
                    timerItem.MenuItems.Add(timerResumeItem);
                    timerResumeItem.Click += TimerResume;
                    timerPauseWasClicked = true;
                }

                MenuItem printItem = new MenuItem("Print");
                setImageItem.MenuItems.Add(printItem);
                printItem.Click += PrintImage;

                MenuItem timeCancle = new MenuItem("Cancle");
                timerItem.MenuItems.Add(timeCancle);
                timeCancle.Click += TimerCancel;

                MenuItem closeItem = new MenuItem("Close");
                closeItem.Click += Close;
                cm.MenuItems.Add(closeItem);
                this.ContextMenu = cm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateOriginalForm(object sender, EventArgs e)
        {
            CreateOriginForm();
        }

        private void Close(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                this.parent.count--;
                if (this.parent.count < 0)
                {
                    this.parent.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                  
            }
        }

        public void CreateOriginForm()
        {
            try
            {
                Form1 f = new Form1(this);
                f.ShowInTaskbar = false;
                f.Show();
                f.BackColor = f.parent.BackColor;
                f.BackgroundImage = f.parent.BackgroundImage;
                f.Size = f.parent.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CreateForm()
        {
            if (count < 7)
            {
                Form1 f = new Form1(this);
                f.ShowInTaskbar = false;
                f.Show();
                this.parent.count++;
            }
        }

        private void CreateDefaultForm(object sender, EventArgs e)
        {
            this.parent.CreateForm();
        }

        private void AddImage(object sender, EventArgs e)
        {
            try
            {
                // Wrap the creation of the OpenFileDialog instance in a using statement,
                // rather than manually calling the Dispose method to ensure proper disposal
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        myimage = new Bitmap(dlg.FileName);
                        this.BackgroundImage = myimage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveImg(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog f = new SaveFileDialog())
                {
                    f.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        myimage.Save(f.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ColorDialog(object sender, EventArgs e)
        {
            try
            {
                // Show the color dialog.
                ColorDialog colorDialog1 = new ColorDialog();
                DialogResult result = colorDialog1.ShowDialog();
                // See if user pressed ok.
                if (result == DialogResult.OK)
                {
                    // Set form background to the selected color.
                    this.BackColor = colorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;
            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
                case 0xa4:
                    Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                    cm.Show(this, this.PointToClient(Cursor.Position));
                    return;
            }
            base.WndProc(ref m);
        }

        private void AddClockSec(object sender, EventArgs e)
        {
            try
            {
                clock.Show();
                DateTime dt = DateTime.Now;
                hourMinSecTime.Start();
                this.clock.Text = dt.ToString("hh:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddClock(object sender, EventArgs e)
        {
            try
            {
                clock.Show();
                DateTime dt = DateTime.Now;
                hourMinTime.Start();
                this.clock.Text = dt.ToString("hh:mm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TimerStart(object sender, EventArgs e)
        {
            try
            {
                hourLabel.Show();
                minuteLabel.Show();
                secondLabel.Show();
                hourBox.Show();
                minuteBox.Show();
                secondBox.Show();
                fileNameBox.Show();
                openFileButton.Show();
                fileLabel.Show();

                if (hourBox.Text == "")
                {
                    hourBox.Text = "59";
                }

                if (minuteBox.Text == "")
                {
                    minuteBox.Text = "59";
                }

                if (secondBox.Text == "")
                {
                    secondBox.Text = "59";
                }

                hour = Convert.ToInt32(hourBox.Text);
                minute = Convert.ToInt32(minuteBox.Text);
                second = Convert.ToInt32(secondBox.Text);

                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            try
            {
                second -= 1;

                if (hour == -1)
                {
                    hour = 59;
                }

                if (second == -1)
                {
                    minute -= 1;
                    second = 59;
                }

                if (minute == -1)
                {
                    hour -= 1;
                    minute = 59;
                }

                if (hour == 0 && minute == 0 && second == 0)
                {
                    player = new SoundPlayer();

                    player.SoundLocation = @"C:\alarm.wav";
                    try
                    {
                        player.PlayLooping();
                        timer1.Stop();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }

                if (OpenFileButtonWasClicked)
                {
                    if (hour == 0 && minute == 0 && second == 0)
                    {
                        player = new SoundPlayer();

                        if (string.IsNullOrEmpty(fileNameBox.Text))
                            return;

                        player.SoundLocation = fileNameBox.Text;

                        player.PlayLooping();
                        timer1.Stop();
                    }
                }

                string h = Convert.ToString(hour);
                string m = Convert.ToString(minute);
                string s = Convert.ToString(second);

                hourLabel.Text = h;
                minuteLabel.Text = m;
                secondLabel.Text = s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TimerPause(object sender, EventArgs e)
        {
            try
            {
                CreateContextMenu();
                timer1.Stop();
                player.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TimerResume(object sender, EventArgs e)
        {
            try
            {
                CreateContextMenu();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TimerCancel(object sender, EventArgs e)
        {
            try
            {
                clock.Hide();
                hourLabel.Hide();
                minuteLabel.Hide();
                secondLabel.Hide();
                hourBox.Hide();
                minuteBox.Hide();
                secondBox.Hide();
                player.Stop();
                fileNameBox.Hide();
                openFileButton.Hide();
                fileLabel.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         
        }

        private void OpenFileButton(object sender, EventArgs e)
        {
            try
            {
                OpenFileButtonWasClicked = true;
                using (OpenFileDialog fd = new OpenFileDialog() { Filter = "WAV|*.wav", Multiselect = false, ValidateNames = true })
                {
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        fileNameBox.Text = fd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void PrintImage(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (senders, args) =>
                {
                    Point p = new Point(100, 100);
                    args.Graphics.DrawImage(myimage, 10, 10, myimage.Width, myimage.Height);
                    args.Graphics.DrawImage(myimage, args.MarginBounds);
                };
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                Image img = Image.FromFile("D:\\Foto.jpg");
                Point loc = new Point(100, 100);
                e.Graphics.DrawImage(img, loc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadForm(object sender, EventArgs e)
        {
            try
            {
                clock.Hide();
                hourLabel.Hide();
                minuteLabel.Hide();
                secondLabel.Hide();
                hourBox.Hide();
                minuteBox.Hide();
                secondBox.Hide();
                fileNameBox.Hide();
                openFileButton.Hide();
                fileLabel.Hide();
                this.BackColor = System.Drawing.Color.Yellow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}





