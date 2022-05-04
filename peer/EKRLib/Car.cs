using System;
using System.Collections.Generic;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс Car, наследуемый от Transport.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="model">Модель машины.</param>
        /// <param name="power">Мощность машины.</param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Метод преобразования объекта Car к строке.
        /// </summary>
        /// <returns>Строковое представления объекта Car.</returns>
        public override string ToString()
        {
            return $"Car. {base.ToString()}";
        }

        /// <summary>
        /// Метод вывода звука машины.
        /// </summary>
        /// <returns>Звук машины в строковом представлении.</returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }
    }
}
