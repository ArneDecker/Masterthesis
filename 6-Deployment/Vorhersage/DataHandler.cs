using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vorhersage
{
    internal class DataHandler
    {

        public DataHandler() { }

        public Series loadData(DateTime dateFrom, DateTime dateTo)
        {

            List<DateTime> index = new List<DateTime>();
            List<int> forecast = new List<int>();
            List<int> actual = new List<int>();
            List<int> residual = new List<int>();
            List<int> baseline = new List<int>();

            using (var reader = new StreamReader("python/api_data/historic_values.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    String line = reader.ReadLine();
                    String[] values = line.Split(',');

                    String[] dateString = values[0].Split('-');
                    int year = Convert.ToInt32(dateString[0]);
                    int month = Convert.ToInt32(dateString[1]);
                    int day = Convert.ToInt32(dateString[2]);

                    DateTime date = new DateTime(year, month, day);

                    if (date >= dateFrom && date <= dateTo)
                    {

                        index.Add(date);

                        forecast.Add(Convert.ToInt32(values[1]));
                        actual.Add(Convert.ToInt32(values[2]));
                        residual.Add(Convert.ToInt32(values[3]));
                        baseline.Add(Convert.ToInt32(values[4]));

                    }

                }

                reader.Close();

            }

            Series series = new Series(index, forecast, actual, residual, baseline);

            return series;

        }

    }
}
