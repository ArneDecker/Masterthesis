using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Vorhersage
{
    public partial class Frame : Form
    {

        private DataHandler dataHandler;

        public Frame()
        {
            InitializeComponent();

            dataHandler = new DataHandler();

        }

        private void btLoadData_Clicked(object sender, EventArgs e)
        {

            Series series = dataHandler.loadData(datePickerFrom.Value, datePickerTo.Value);

            displayData(series);

        }

        private void btForecast_Click(object sender, EventArgs e)
        {

            Series series = dataHandler.loadData(datePickerFrom.Value, datePickerTo.Value);

            int new_forecast = generateForecast();

            series.addForecast(new_forecast);

            tbForecastDisplay.Text = new_forecast.ToString();
            tbForecastDate.Text = series.getLastIndex();

            displayData(series);

        }

        private int generateForecast()
        {

            string runtimePath = Directory.GetCurrentDirectory() + "\\";

            int arbeitstag = cbArbeitstag.Checked ? 1 : 0;
            String temperatur = nfTemperatur.Text;
            String tagesstunden = nfTagesstunden.Text;

            string lines = "arbeitstag,temperatur,tagesstunden\n" +
                "" + arbeitstag + "," + temperatur + "," + tagesstunden;

            File.WriteAllText("python/api_data/exog_next_day.csv", lines);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " +
                "D: &" +
                "cd " + runtimePath + "/python &" +
                "python forecasting.py";
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            String output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            int new_forecast = Convert.ToInt32(output);

            return new_forecast;

        }

        private void displayData(Series series)
        {

            tbForecastDate.Text = (series.getLastIndex());
            tbForecastDisplay.Text = (series.getLastForecast());

            List<DateTime> index = series.getIndex();
            List<int> forecast = series.getForecast();
            List<int> actual = series.getActual();
            List<int> residual = series.getResidual();
            List<int> baseline = series.getBaseline();

            forecastPlot.Series["Forecast"].Points.Clear();
            forecastPlot.Series["Actual"].Points.Clear();
            forecastPlot.Series["Baseline"].Points.Clear();
            residualPlot.Series["Residual"].Points.Clear();

            forecastPlot.Series["Forecast"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            forecastPlot.Series["Actual"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            forecastPlot.Series["Baseline"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            residualPlot.Series["Residual"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;

            for (int i = 0; i < index.Count; i++)
            {

                DateTime dateTime = series.getIndex()[i];

                if (i == 0) { datePickerFrom.Value = dateTime; }
                if (i == index.Count - 1) { datePickerTo.Value = dateTime; }

                forecastPlot.Series["Forecast"].Points.AddXY(dateTime, forecast[i]);

                if (i < actual.Count) { forecastPlot.Series["Actual"].Points.AddXY(dateTime, actual[i]); }
                if (i < baseline.Count) { forecastPlot.Series["Baseline"].Points.AddXY(dateTime, baseline[i]); }
                if (i < residual.Count) { residualPlot.Series["Residual"].Points.AddXY(dateTime, residual[i]); }
                
            }

        }

    }
}
