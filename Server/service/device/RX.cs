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
    }
}
