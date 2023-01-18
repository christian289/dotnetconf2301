using FarPoint.Excel;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Data;
using System.ComponentModel;

namespace GCKSpreadDotnet
{
    public partial class Form1 : Form
    {
        SpreadDataBindingAdapter dataAdapter;
        BindingList<Entity> ds;
        SpreadDataBindingAdapter timerDataAdapter;
        BindingList<TimerEntity> timerDs;

        public Form1()
        {
            InitializeComponent();
            formulaTextBox1.Attach(fpSpread1);

            ds = new BindingList<Entity>();
            timerDs = new BindingList<TimerEntity>
            {
                new TimerEntity
                {
                    Datetime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
                }
            };

            SetBinding();
            DataInit(ds);

            timer1.Start();
        }

        public void SetBinding()
        {
            dataAdapter = new SpreadDataBindingAdapter
            {
                DataSource = ds,
                Spread = fpSpread1,
                SheetName = "송장",
                MapperInfo = new MapperInfo(10, 1, ds.Count, 2)
            };
            dataAdapter.FillSpreadDataByDataSource();

            timerDataAdapter = new SpreadDataBindingAdapter
            {
                DataSource = timerDs,
                Spread = fpSpread1,
                SheetName = "송장",
                MapperInfo = new MapperInfo(0, 1, 1, 1)
            };
            timerDataAdapter.FillSpreadDataByDataSource();
            label1.DataBindings.Add(nameof(Label.Text), timerDs, nameof(TimerEntity.Datetime));
        }

        public void DataInit(BindingList<Entity> ds)
        {
            ds.Add(new Entity("피카츄", 4000));
            ds.Add(new Entity("라이츄", 5000));
            ds.Add(new Entity("파이리", 6000));
            ds.Add(new Entity("꼬부기", 7000));
            ds.Add(new Entity("버터플", 8000));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var timer in timerDs)
            {
                timer.Datetime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            }
        }

        /// <summary>
        /// PDF print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            PrintInfo printInfo = new();
            printInfo.PrintToPdf = true;
            printInfo.PdfFileName = @$"{Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)}\SavePdfFile.pdf";
            fpSpread1.ActiveSheet.PrintInfo = printInfo;
            fpSpread1.PrintSheet(fpSpread1.ActiveSheetIndex);
        }
    }
}