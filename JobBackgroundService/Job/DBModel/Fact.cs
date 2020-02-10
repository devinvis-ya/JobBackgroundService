using System;
using System.Collections.Generic;
using System.Text;

namespace Job.DBModel
{
    public class Fact
    {
        public int Id { get; set; }
        /// <summary>
        /// Температура (°C)
        /// </summary>
        public int Temp { get; set; }
        /// <summary>
        /// Ощущаемая температура (°C)
        /// </summary>
        public int FeelsLike { get; set; }
        /// <summary>
        /// Код расшифровки погодного описания
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// Скорость ветра (в м/с)
        /// </summary>
        public int WindSpeed { get; set; }
        /// <summary>
        /// Направление ветра
        /// </summary>
        public string WindDirection { get; set; }
        /// <summary>
        /// Давление (в мм рт. ст.)
        /// </summary>
        public int PressureMM { get; set; }
        /// <summary>
        /// Влажность воздуха (в процентах)
        /// </summary>
        public int Humidity { get; set; }
        /// <summary>
        /// Время года в данном населенном пункте
        /// </summary>
        public string Season { get; set; }
    }
}
