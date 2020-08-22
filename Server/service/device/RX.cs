using System;
using System.Collections.Generic;
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
                    if(val <= min / 2) return double.NaN;
                        
                    var k = (maxValue - minValue) / (max - min);
                    var b = minValue - min * k;
                    return val * k + b;
                });
        }
    }
}
