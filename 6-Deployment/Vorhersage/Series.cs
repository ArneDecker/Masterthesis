using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vorhersage
{
    internal class Series
    {

        private List<DateTime> index = new List<DateTime>();
        private List<int> forecast = new List<int>();
        private List<int> actual = new List<int>();
        private List<int> residual = new List<int>();
        private List<int> baseline = new List<int>();

        public Series() {}

        public Series(List<DateTime> index, List<int> forecast, List<int> actual, List<int> residual, List<int> baseline)
        {

            this.index = index;
            this.forecast = forecast;
            this.actual = actual;
            this.residual = residual;
            this.baseline = baseline;

        }
        public String getLastIndex() { return this.index.ElementAt(this.index.Count - 1).ToString().Split(' ')[0]; }
        public String getLastForecast() { return this.forecast.ElementAt(this.index.Count - 1).ToString(); }

        public void setIndex(List<DateTime> index) { this.index = index; }
        public List<DateTime> getIndex() { return this.index; }

        public void setForecast(List<int> forecast) { this.forecast = forecast; }
        public List<int> getForecast() { return this.forecast; }
        public void addForecast(int new_forecast) 
        {

            DateTime new_index = this.index.ElementAt(this.index.Count - 1).AddDays(1);
            this.index.Add(new_index);

            this.forecast.Add(new_forecast);

        }

        public void setActual(List<int> actual) { this.actual = actual;}
        public List<int> getActual() { return this.actual; }

        public void setResidual(List<int> residual) { this.residual = residual; }
        public List<int> getResidual() { return this.residual; }

        public void setBaseline(List<int> baseline) { this.baseline = baseline; }
        public List<int> getBaseline() { return this.baseline; }

    }
}
