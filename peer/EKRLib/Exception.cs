using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс исключения TransportException.
    /// </summary>
    public class TransportException : Exception {
        /// <summary>
        /// Конструкторы, наследуемые от Exeption.
        /// </summary>
        public TransportException() : base() { }

        /// <summary>
        /// Конструкторы, наследуемые от Exeption.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        public TransportException(string message) : base(message) { }

        /// <summary>
        /// Конструкторы, наследуемые от Exeption.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        /// <param name="inner"></param>
        public TransportException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Конструкторы, наследуемые от Exeption.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
