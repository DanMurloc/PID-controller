using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PID
{
    public class PIDController
    {
        public double Kp { get; set; } // Пропорциональный коэффициент
        public double Ki { get; set; } // Интегральный коэффициент
        public double Kd { get; set; } // Дифференциальный коэффициент

        private double previousError; // Предыдущая ошибка
        private double integral; // Интегральная составляющая
        private double setPoint; // Заданное значение

        public PIDController(double kp, double ki, double kd)
        {
            Kp = kp;
            Ki = ki;
            Kd = kd;
            previousError = 0;
            integral = 0;
        }

        public void SetSetPoint(double setPoint)
        {
            this.setPoint = setPoint;
        }

        public double Compute(double actualValue, double deltaTime)
        {
            // Вычисление ошибки
            double error = setPoint - actualValue;

            // Пропорциональная составляющая
            double proportional = Kp * error;

            // Интегральная составляющая
            integral += error * deltaTime;
            double integralTerm = Ki * integral;

            // Дифференциальная составляющая
            double derivative = (error - previousError) / deltaTime;
            double derivativeTerm = Kd * derivative;

            // Суммирование всех составляющих
            double output = proportional + integralTerm + derivativeTerm;

            // Обновление предыдущей ошибки
            previousError = error;

            return output;
        }

    }

}
