using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Core.Utilities.Normalization
{

    public class ExpectedCurveNormalizer
    {
        public NormalizationOptions NormalizationOptions { get; set; } = new NormalizationOptions();
        public IEnumerable<KeyValuePair<double, double>> NormalizeItems(IDictionary<double, double> expectedCurveItems, IDictionary<double, double> actualItems)
        {
            var averageValues = ComputeAverageValues(expectedCurveItems, actualItems);
            var expectedGradients = FindGradients(averageValues.ToList());
            var percentDifferences =expectedCurveItems.Select(kvp => new {kvp.Key,percentError = (actualItems[kvp.Key] - kvp.Value)/actualItems[kvp.Key]});


            //ToDo using best key and gradient is not best way to compute normalized items, best key distance is penalized.
            var bestActualKey = percentDifferences.OrderByDescending(pd => pd.percentError).Select(i=>i.Key).First();
            Dictionary<double,double> normalizedItems = new Dictionary<double, double>();
            normalizedItems.Add(bestActualKey,actualItems[bestActualKey]);

            var keyToEnd = expectedGradients.SkipWhile(kvp => kvp.Key != bestActualKey).Skip(1).ToList();
            var lastItem = actualItems[bestActualKey];
            foreach (var kvp in keyToEnd)
            {
                lastItem = lastItem*kvp.Value;
                normalizedItems.Add(kvp.Key,lastItem);
            }

            var keyToStart = expectedGradients.Reverse().SkipWhile(kvp => kvp.Key != bestActualKey).ToList();
            var prevItem = actualItems[bestActualKey];
            foreach (var kvp in keyToStart)
            {
                prevItem = prevItem / kvp.Value;
                var index = expectedGradients.Keys.ToList().IndexOf(kvp.Key);
                var key = actualItems.ToList()[index].Key;
                normalizedItems.Add(key, prevItem);
            }

            return normalizedItems.OrderBy(i=>i.Key);
        }

        
        private IDictionary<double, double> ComputeAverageValues(IDictionary<double, double> expectedItems, IDictionary<double, double> actualItems)
        {
             Dictionary<double,double> averageItems = new Dictionary<double, double>();
            var ew = NormalizationOptions.ExpectedWeight;
            var aw = NormalizationOptions.ActualWeight;
            foreach (var key in expectedItems.Keys)
            {
                var averageValue = (expectedItems[key]*ew + actualItems[key]*aw)/(aw+ew);
                averageItems.Add(key,averageValue);
            }
            return averageItems;
        }

        private IDictionary<double, double> FindGradients(IList<KeyValuePair<double, double>> items)
        {
            Dictionary<double,double> gradients = new Dictionary<double, double>();
            items = items.ToList();
            for (int i = 1; i < items.Count(); i++)
            {
                var x1 = items[i - 1].Value;
                var x2 = items[i].Value;
                var y = items[i].Key;
                var gradient = x2/x1;
                gradients.Add(y,gradient);
            }
            return gradients;
        }
    }
}
