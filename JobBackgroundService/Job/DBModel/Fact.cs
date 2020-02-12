using System;
using System.Collections.Generic;
using System.Text;

namespace Job.DBModel
{
    public class Fact
    {
        public Fact()
        {
            CreateDate = DateTime.Now;
        }
        public Fact(YaModel.Fact fact) : this ()
        {
            Temp = fact.Temp;
            FeelsLike = fact.Feels_like;
            Condition = fact.Condition;
            WindSpeed = fact.Wind_speed;
            WindDirection = fact.Wind_dir;
            PressureMM = fact.Pressure_mm;
            Humidity = fact.Humidity;
            Season = fact.Season;
        }
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
        public double WindSpeed { get; set; }
        /// <summary>
        /// Направление ветра
        /// </summary>
        public string WindDirection { get; set; }
        /// <summary>
        /// Давление (в мм рт. ст.)
        /// </summary>
        public double PressureMM { get; set; }
        /// <summary>
        /// Влажность воздуха (в процентах)
        /// </summary>
        public double Humidity { get; set; }
        /// <summary>
        /// Время года в данном населенном пункте
        /// </summary>
        public string Season { get; set; }
        /// <summary>
        /// Дата записи в БД
        /// </summary>
        public int PlaceId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
