using System;
using System.Collections.Generic;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс MotorBoat, наследуемый от Transport.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="model">Модель лодки.</param>
        /// <param name="power">Мощность лодки.</param>
        public MotorBoat(string model, uint power) : base(model, power) {}

        /// <summary>
        /// Метод преобразования объекта MotorBoat к строке.
        /// </summary>
        /// <returns>Строковое представления объекта MotorBoat.</returns>
        public override string ToString()
        {
            return $"MotorBoat. {base.ToString()}";
        }

        /// <summary>
        /// Метод вывода звука лодки.
        /// </summary>
        /// <returns>Звук лодки в строковом представлении.</returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }
    }
}
