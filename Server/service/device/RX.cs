using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace SafeServer.service.device
{
    public static class RX
    {
        public static IObservable<bool> ToBool(this IObservable<Tuple<bool[], int>> observable)
        {
            return observable.Select(value =>
            {
                var (array, len) = value;
                var result = false;
                for (var i = 0; i < len; i++)
                    result = result || array[i];
                return result;
            });
        }
        
        public static IObservable<bool> ToThresholdRate(this IObservable<Tuple<bool[], int>> observable, int countPerMin)
        {
            const int k = 2; 
            var timeOneCircle = TimeSpan.FromMilliseconds(60.0 * 1000.0 / countPerMin);
            var seed = Tuple.Create(false, 0);
            return observable.Scan(seed, DetectCircle)
                .Window(k * timeOneCircle, timeOneCircle)
                .SelectMany(o => o.Aggregate(0, (i, tuple) => i + tuple.Item2))
                .Select(count => count > k);
        }
        
        public static IObservable<double> ToMean(this IObservable<Tuple<double[], int>> observable)
        {
            return observable.Select(value =>
            {
                var (array, len) = value;
                var sum = 0.0;
                for (var i = 0; i < len; i++)
                    sum += array[i];
                return sum / len;
            });
        }
        
        public static IObservable<double> Convert(this IObservable<double> observable, double min, double max, double minValue, double maxValue)
        {
            return observable.Select(val =>
                {
                    var k = (maxValue - minValue) / (max - min);
                    var b = minValue - min * k;
                    return val * k + b;
                });
        }
        
        public static IObservable<double> FlatMap(this IObservable<Tuple<double[], int>> observable)
        {
            return observable.SelectMany(val => val.Item1.Take(val.Item2));
        }
        
        private static Tuple<bool, int> DetectCircle(Tuple<bool, int> seed, Tuple<bool[], int> value)
        {
            var (array, len) = value;
            var last = seed.Item1;
            var count = 0;

            for (var i = 0; i < len; i++)
            {
                if (array[i] == last) continue;
                if (array[i]) count++;
                last = array[i];
            }

            return Tuple.Create(last, count > 0 ? 1 : 0); 
        }

    }
}
