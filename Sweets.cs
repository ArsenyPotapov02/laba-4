using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba_4
{

    public class Sweets
    {
        public static Random rnd = new Random();
        public int Weight = 0;
        public virtual String GetInfo()
        {

            var str = String.Format("\nВес: {0}", this.Weight);
            return str;
        }
    }
    public enum ChocolateType { dark, lactic };
    public class Chocolate : Sweets
    {
        public bool Filling = false; // начинка
        public int SliceCount = 0; // количество плиток
        public ChocolateType type = ChocolateType.dark; // наличие листика


        public override String GetInfo()
        {
            var str1 = "";
            switch (type)
            {
                case ChocolateType.dark:
                    str1 = "темный";
                    break;
                case ChocolateType.lactic:
                    str1 = "молочный";
                    break;
            }
            var str = "Шоколад";
            str += base.GetInfo();
            // Добавил
            str += String.Format("\nКоличество долек: {0}", this.SliceCount);
            str += String.Format("\nНачинка: {0}", this.Filling  ? "начиннка есть" : "начинки нет");
            str += String.Format("\nТип: {0}", str1);
            return str;
        }
        public static Chocolate Generate()
        {

            return new Chocolate
            {
                type = (ChocolateType)rnd.Next(2),
                SliceCount = 5 + rnd.Next() % 20,
                Filling = rnd.Next() % 2 == 0,
                Weight = 50 + rnd.Next() % 300
            };
        }
    }
    public enum BakeryType { bread, donut, cake };
    class Bakery : Sweets
    {
        public BakeryType type = BakeryType.bread; // вид выпечки
        public int EnergyValue = 0; // энергет ценность
        public override String GetInfo()
        {
            var str1 = "";
            switch (type)
            {
                case BakeryType.bread:
                    str1 = "хлеб";
                    break;
                case BakeryType.donut:
                    str1 = "пончик";
                    break;
                case BakeryType.cake:
                    str1 = "торт";
                    break;
            }
            var str = "Выпечка";
            str += base.GetInfo();
            str += String.Format("\nЭнергетическая ценность: {0}", this.EnergyValue);
            str += String.Format("\nТип: {0}", str1);
            return str;
        }
        public static Bakery Generate()
        {

            return new Bakery
            {
                type = (BakeryType)rnd.Next(2),
                EnergyValue = 250 + rnd.Next(500),
                Weight = 50 + rnd.Next() % 300
            };
        }

    }
    public enum FruitsType { orange, kiwi, banana, apple };
    class Fruits : Sweets
    {

        public int Ripeness = 0; // спелость
        public FruitsType type = FruitsType.orange; // тип
        public override String GetInfo()
        {
            var str1 = "";
            switch (type)
            {
                case FruitsType.orange:
                     str1 = "апельсин";
                    break;
                case FruitsType.kiwi:
                     str1 = "киви";
                    break;
                case FruitsType.banana:
                     str1 = "банан";
                    break;
                case FruitsType.apple:
                     str1 = "яблоко";
                    break;
            }
            var str = "Фрукты";
            str += base.GetInfo();

            str += String.Format("\nСпелость: {0}", this.Ripeness);
            str += String.Format("\nТип: {0}", str1);
            return str;
        }
        public static Fruits Generate()
        {

            return new Fruits
            {
                type = (FruitsType)rnd.Next(2),
                Ripeness = rnd.Next() % 100,
                Weight = 50 + rnd.Next() % 300
            };
        }
    }





}