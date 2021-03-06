using System.Globalization;
using SAMA.Framework.Common.Interfaces;

namespace SAMA.Framework.Common
{
    internal static class AggregateExtensionMethods
    {
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format ?? string.Empty, args);
        }

        public static void ThrowHandlerNotFound(this IContainsEventAggregate aggregate, object eventMessage)
        {
            var exceptionMessage = "Aggregate of type '{0}' raised an event of type '{1}' but not handler could be found to handle the message."
                .FormatWith(aggregate.GetType().Name, eventMessage.GetType().Name);

            throw new HandlerForDomainEventNotFoundException(exceptionMessage);
        }
    }
}