using System;

namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс Transport.
    /// </summary>
    public abstract class Transport
    {
        string model;
        uint power;
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="model">Модель транспортного средства.</param>
        /// <param name="power">Мощность транспортного средства.</param>
        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Свойство: модель транспортного средства.
        /// </summary>
        public string Model
        {
            get { return model; }
            private set
            {
                foreach (var item in value)
                {
                    if (!char.IsUpper(item) && !char.IsNumber(item))
                        throw new TransportException($"Недопустимая модель {value}");
                }
                if (value.Length != 5)
                {
                    throw new TransportException($"Недопустимая модель {value}");
                }
                model = value;
            }
        }

        /// <summary>
        /// Свойство: мощность транспортного средства.
        /// </summary>
        public uint Power
        {
            get { return power; }
            private set
            {
                if (value < 20)
                {
                    throw new TransportException("мощность не может быть меньше 20 л.с.");
                }
                power = value;
            }
        }

        /// <summary>
        /// Метод преобрахования объекта Transport к строке.
        /// </summary>
        /// <returns>Строковое представление объекта Transport.</returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }

        /// <summary>
        /// Абстрактный метод звука транспортного средства.
        /// </summary>
        /// <returns></returns>
        public abstract string StartEngine();
    }
}
