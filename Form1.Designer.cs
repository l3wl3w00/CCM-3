namespace Meres3
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this._testButton = new System.Windows.Forms.Button();
            this._screenValueLabel = new System.Windows.Forms.Label();
            this._toVoltButton = new System.Windows.Forms.Button();
            this._toResButton = new System.Windows.Forms.Button();
            this._isSavedCheckBox = new System.Windows.Forms.CheckBox();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._toAuto = new System.Windows.Forms.Button();
            this._toHalfButton = new System.Windows.Forms.Button();
            this._toFiveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            this.SuspendLayout();
            // 
            // _testButton
            // 
            this._testButton.Location = new System.Drawing.Point(13, 13);
            this._testButton.Name = "_testButton";
            this._testButton.Size = new System.Drawing.Size(98, 33);
            this._testButton.TabIndex = 0;
            this._testButton.Text = "Start";
            this._testButton.UseVisualStyleBackColor = true;
            // 
            // _screenValueLabel
            // 
            this._screenValueLabel.AutoSize = true;
            this._screenValueLabel.Location = new System.Drawing.Point(133, 19);
            this._screenValueLabel.Name = "_screenValueLabel";
            this._screenValueLabel.Size = new System.Drawing.Size(0, 20);
            this._screenValueLabel.TabIndex = 1;
            // 
            // _toVoltButton
            // 
            this._toVoltButton.Location = new System.Drawing.Point(13, 71);
            this._toVoltButton.Name = "_toVoltButton";
            this._toVoltButton.Size = new System.Drawing.Size(176, 39);
            this._toVoltButton.TabIndex = 2;
            this._toVoltButton.Text = "Measure Voltage";
            this._toVoltButton.UseVisualStyleBackColor = true;
            // 
            // _toResButton
            // 
            this._toResButton.Location = new System.Drawing.Point(12, 116);
            this._toResButton.Name = "_toResButton";
            this._toResButton.Size = new System.Drawing.Size(176, 39);
            this._toResButton.TabIndex = 3;
            this._toResButton.Text = "Measure Resistance";
            this._toResButton.UseVisualStyleBackColor = true;
            // 
            // _isSavedCheckBox
            // 
            this._isSavedCheckBox.AutoSize = true;
            this._isSavedCheckBox.Location = new System.Drawing.Point(13, 180);
            this._isSavedCheckBox.Name = "_isSavedCheckBox";
            this._isSavedCheckBox.Size = new System.Drawing.Size(68, 24);
            this._isSavedCheckBox.TabIndex = 4;
            this._isSavedCheckBox.Text = "save";
            this._isSavedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _chart
            // 
            chartArea2.Name = "ChartArea1";
            this._chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this._chart.Legends.Add(legend2);
            this._chart.Location = new System.Drawing.Point(221, 62);
            this._chart.Name = "_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this._chart.Series.Add(series2);
            this._chart.Size = new System.Drawing.Size(863, 753);
            this._chart.TabIndex = 5;
            this._chart.Text = "chart1";
            // 
            // _toAuto
            // 
            this._toAuto.Location = new System.Drawing.Point(13, 233);
            this._toAuto.Name = "_toAuto";
            this._toAuto.Size = new System.Drawing.Size(175, 49);
            this._toAuto.TabIndex = 6;
            this._toAuto.Text = "Auto";
            this._toAuto.UseVisualStyleBackColor = true;
            // 
            // _toHalfButton
            // 
            this._toHalfButton.Location = new System.Drawing.Point(13, 288);
            this._toHalfButton.Name = "_toHalfButton";
            this._toHalfButton.Size = new System.Drawing.Size(175, 49);
            this._toHalfButton.TabIndex = 7;
            this._toHalfButton.Text = "0.5";
            this._toHalfButton.UseVisualStyleBackColor = true;
            // 
            // _fiveButton
            // 
            this._toFiveButton.Location = new System.Drawing.Point(14, 343);
            this._toFiveButton.Name = "_toFiveButton";
            this._toFiveButton.Size = new System.Drawing.Size(175, 49);
            this._toFiveButton.TabIndex = 8;
            this._toFiveButton.Text = "5";
            this._toFiveButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 837);
            this.Controls.Add(this._toFiveButton);
            this.Controls.Add(this._toHalfButton);
            this.Controls.Add(this._toAuto);
            this.Controls.Add(this._chart);
            this.Controls.Add(this._isSavedCheckBox);
            this.Controls.Add(this._toResButton);
            this.Controls.Add(this._toVoltButton);
            this.Controls.Add(this._screenValueLabel);
            this.Controls.Add(this._testButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _testButton;
        private System.Windows.Forms.Label _screenValueLabel;
        private System.Windows.Forms.Button _toVoltButton;
        private System.Windows.Forms.Button _toResButton;
        private System.Windows.Forms.CheckBox _isSavedCheckBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chart;
        private System.Windows.Forms.Button _toAuto;
        private System.Windows.Forms.Button _toHalfButton;
        private System.Windows.Forms.Button _toFiveButton;
    }
}