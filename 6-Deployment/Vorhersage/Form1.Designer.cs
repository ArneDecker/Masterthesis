namespace Vorhersage
{
    partial class Frame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.forecastPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.residualPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btLoadData = new System.Windows.Forms.Button();
            this.btForecast = new System.Windows.Forms.Button();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbForecastDate = new System.Windows.Forms.TextBox();
            this.tbForecastDisplay = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbArbeitstag = new System.Windows.Forms.CheckBox();
            this.nfTemperatur = new System.Windows.Forms.TextBox();
            this.nfTagesstunden = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.forecastPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.residualPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // forecastPlot
            // 
            chartArea3.Name = "ChartArea1";
            this.forecastPlot.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.forecastPlot.Legends.Add(legend3);
            this.forecastPlot.Location = new System.Drawing.Point(12, 12);
            this.forecastPlot.Name = "forecastPlot";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Forecast";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "Actual";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "Baseline";
            this.forecastPlot.Series.Add(series5);
            this.forecastPlot.Series.Add(series6);
            this.forecastPlot.Series.Add(series7);
            this.forecastPlot.Size = new System.Drawing.Size(1880, 500);
            this.forecastPlot.TabIndex = 0;
            this.forecastPlot.Text = "chart1";
            this.forecastPlot.UseWaitCursor = true;
            // 
            // residualPlot
            // 
            chartArea4.Name = "ChartArea1";
            this.residualPlot.ChartAreas.Add(chartArea4);
            legend4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.residualPlot.Legends.Add(legend4);
            this.residualPlot.Location = new System.Drawing.Point(12, 518);
            this.residualPlot.Name = "residualPlot";
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Residual";
            this.residualPlot.Series.Add(series8);
            this.residualPlot.Size = new System.Drawing.Size(1880, 300);
            this.residualPlot.TabIndex = 1;
            this.residualPlot.Text = "chart1";
            // 
            // btLoadData
            // 
            this.btLoadData.Location = new System.Drawing.Point(12, 824);
            this.btLoadData.Name = "btLoadData";
            this.btLoadData.Size = new System.Drawing.Size(161, 94);
            this.btLoadData.TabIndex = 2;
            this.btLoadData.Text = "Daten laden";
            this.btLoadData.UseVisualStyleBackColor = true;
            this.btLoadData.Click += new System.EventHandler(this.btLoadData_Clicked);
            // 
            // btForecast
            // 
            this.btForecast.Location = new System.Drawing.Point(12, 935);
            this.btForecast.Name = "btForecast";
            this.btForecast.Size = new System.Drawing.Size(161, 94);
            this.btForecast.TabIndex = 4;
            this.btForecast.Text = "Vorhersage erstelllen";
            this.btForecast.UseVisualStyleBackColor = true;
            this.btForecast.Click += new System.EventHandler(this.btForecast_Click);
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Location = new System.Drawing.Point(252, 859);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.datePickerFrom.TabIndex = 7;
            this.datePickerFrom.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // datePickerTo
            // 
            this.datePickerTo.Location = new System.Drawing.Point(516, 859);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(200, 20);
            this.datePickerTo.TabIndex = 8;
            this.datePickerTo.Value = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 859);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Von";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 859);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "bis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(512, 935);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Stromverbrauch am:";
            // 
            // tbForecastDate
            // 
            this.tbForecastDate.Enabled = false;
            this.tbForecastDate.Location = new System.Drawing.Point(671, 934);
            this.tbForecastDate.Name = "tbForecastDate";
            this.tbForecastDate.Size = new System.Drawing.Size(128, 20);
            this.tbForecastDate.TabIndex = 12;
            // 
            // tbForecastDisplay
            // 
            this.tbForecastDisplay.Enabled = false;
            this.tbForecastDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbForecastDisplay.Location = new System.Drawing.Point(516, 959);
            this.tbForecastDisplay.Name = "tbForecastDisplay";
            this.tbForecastDisplay.Size = new System.Drawing.Size(283, 70);
            this.tbForecastDisplay.TabIndex = 13;
            this.tbForecastDisplay.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 941);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Arbeitstag:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 976);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Temperatur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 1016);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tagesstunden";
            // 
            // cbArbeitstag
            // 
            this.cbArbeitstag.AutoSize = true;
            this.cbArbeitstag.Location = new System.Drawing.Point(292, 940);
            this.cbArbeitstag.Name = "cbArbeitstag";
            this.cbArbeitstag.Size = new System.Drawing.Size(73, 17);
            this.cbArbeitstag.TabIndex = 17;
            this.cbArbeitstag.Text = "Arbeitstag";
            this.cbArbeitstag.UseVisualStyleBackColor = true;
            // 
            // nfTemperatur
            // 
            this.nfTemperatur.Location = new System.Drawing.Point(292, 973);
            this.nfTemperatur.Name = "nfTemperatur";
            this.nfTemperatur.Size = new System.Drawing.Size(100, 20);
            this.nfTemperatur.TabIndex = 18;
            this.nfTemperatur.Text = "-3";
            // 
            // nfTagesstunden
            // 
            this.nfTagesstunden.Location = new System.Drawing.Point(292, 1013);
            this.nfTagesstunden.Name = "nfTagesstunden";
            this.nfTagesstunden.Size = new System.Drawing.Size(100, 20);
            this.nfTagesstunden.TabIndex = 19;
            this.nfTagesstunden.Text = "8.4";
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.nfTagesstunden);
            this.Controls.Add(this.nfTemperatur);
            this.Controls.Add(this.cbArbeitstag);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbForecastDisplay);
            this.Controls.Add(this.tbForecastDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerTo);
            this.Controls.Add(this.datePickerFrom);
            this.Controls.Add(this.btForecast);
            this.Controls.Add(this.btLoadData);
            this.Controls.Add(this.residualPlot);
            this.Controls.Add(this.forecastPlot);
            this.Name = "Frame";
            this.Text = "Vorhersage des Stromverbrauchs für Baden-Württemberg";
            ((System.ComponentModel.ISupportInitialize)(this.forecastPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.residualPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart forecastPlot;
        private System.Windows.Forms.DataVisualization.Charting.Chart residualPlot;
        private System.Windows.Forms.Button btLoadData;
        private System.Windows.Forms.Button btForecast;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbForecastDate;
        private System.Windows.Forms.RichTextBox tbForecastDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbArbeitstag;
        private System.Windows.Forms.TextBox nfTemperatur;
        private System.Windows.Forms.TextBox nfTagesstunden;
    }
}

