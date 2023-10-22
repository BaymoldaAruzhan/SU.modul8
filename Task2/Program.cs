using System;

class UtilityPaymentCalculator
{
    private double heatingRate; // тариф на отопление за 1 м^2
    private double waterRate;   // тариф на воду за 1 человека
    private double gasRate;     // тариф на газ за 1 человека
    private double repairRate;  // тариф на текущий ремонт за 1 м^2

    public UtilityPaymentCalculator(double heatingRate, double waterRate, double gasRate, double repairRate)
    {
        this.heatingRate = heatingRate;
        this.waterRate = waterRate;
        this.gasRate = gasRate;
        this.repairRate = repairRate;
    }

    // Индексатор для расчета коммунальных платежей
    public double this[string paymentType, double area, int residents, bool isWinter, bool hasVeteranDiscount]
    {
        get
        {
            double payment = 0;

            if (paymentType == "Heating")
            {
                payment = area * heatingRate * (isWinter ? 1.2 : 1);
            }
            else if (paymentType == "Water")
            {
                payment = residents * waterRate;
            }
            else if (paymentType == "Gas")
            {
                payment = residents * gasRate;
            }
            else if (paymentType == "Repair")
            {
                payment = area * repairRate;
            }

            if (hasVeteranDiscount)
            {
                // Применение льготы
                payment *= 0.7; // 30% скидка
            }

            return payment;
        }
    }
}

class Program
{
    static void Main()
    {
        // Создание экземпляра калькулятора коммунальных платежей
        UtilityPaymentCalculator calculator = new UtilityPaymentCalculator(0.1, 10, 20, 5);

        // Вывод таблицы с расчетами
        Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");
        double totalPayment = 0;

        double heatingPayment = calculator["Heating", 100, 4, true, false];
        Console.WriteLine("Отопление\t" + heatingPayment + "\t0\t" + heatingPayment);
        totalPayment += heatingPayment;

        double waterPayment = calculator["Water", 4, 4, false, true];
        Console.WriteLine("Вода\t" + waterPayment + "\t" + (0.3 * waterPayment) + "\t" + (waterPayment - 0.3 * waterPayment));
        totalPayment += waterPayment - 0.3 * waterPayment;

        double gasPayment = calculator["Gas", 4, 4, false, false];
        Console.WriteLine("Газ\t" + gasPayment + "\t0\t" + gasPayment);
        totalPayment += gasPayment;

        double repairPayment = calculator["Repair", 100, 4, false, false];
        Console.WriteLine("Ремонт\t" + repairPayment + "\t0\t" + repairPayment);
        totalPayment += repairPayment;

        Console.WriteLine("Итого\t" + totalPayment);
    }
}
