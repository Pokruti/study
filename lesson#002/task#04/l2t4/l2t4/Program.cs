using System;

namespace l2t4
{
    class Program
    {
        static void Main(string[] args)
        {
            string strKKT = "009030404";
            long iINN = 7734506918;
            string strFirst = "Борщ 'Теремковский'";
            string strSecond = "ВТОРОЕ БЛЮДО в составе";
            string strThird = "Котлетки куриные";
            string strFourth = "Пюре картофельное";
            string strFifth = "Узвар шиповник";
            string strNDS = "НДС 20%";
            string strFNS = "http://www.nalog.ru";
            double costFirst = 194.00;
            double costThird = 128.57;
            double costFourth = 75.43;
            double costFifth = 49.00;
            double costTotal = costFirst + costThird + costFourth + costFifth;
            double cPay = 1000.00;
            int countStrThird = 2;
            int numDok = 212373;
            double countStrFourth = 0.2;
            var Ti = DateTime.Now;
            Console.WriteLine("\t\t  АО 'Теремо-Инвест'");
            Console.WriteLine("\t\tТК 'ТВОЙ ДОМ' Новая Рига");
            Console.WriteLine(
                $"ЗН ККТ {strKKT}\t\t\t   ИНН {iINN}\n" +
                 "КАССОВЫЙ ЧЕК / ПРИХОД\n" +
                $"{strFirst}\t\t{strNDS}\t\t{costFirst,8:c} \n" +
                "---------------------------------------------------------\n" +
                $"{strSecond}\t\t{strNDS}\t\t\n" +
                "---------------------------------------------------------\n" +
                $"-{strThird} {countStrThird} шт.\t\t{strNDS}\t\t{costThird,8:c}\n" +
                $"-{strFourth}\t\t{strNDS}\t\t {costFourth,8:c}\n" +
                "---------------------------------------------------------\n" +
                $"{strFifth} {countStrFourth} л\t\t{strNDS}\t\t {costFifth,8:c}\n"+
                "".PadRight(57, '-')
                             );
                Console.WriteLine(
                $"ИТОГ\t\t\t\t\t\t{costTotal,8:c}\n"+
                $"сумма {strNDS}\t\t\t\t\t {costTotal*0.2,8:c}\n"+
                "---------------------------------------------------------\n"+
                $"Наличными\t\t\t\t      {cPay,8:c}\n"+
                "---------------------------------------------------------\n"+
                $"Сдача\t\t\t\t\t\t{cPay-costTotal,8:c}\n"+
                $"Сайт ФНС: {strFNS}\n"+
                $"Дата {Ti.ToString("d")}\t\tВремя {Ti.ToString("t")}\n"+
                $"Док. №{numDok}"
                );
            Console.ReadKey();
        }
    }
}
