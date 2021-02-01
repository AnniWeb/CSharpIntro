namespace les4
{
    public class Task3
    {
        public enum Seasons
        {
            Winter, 
            Spring, 
            Summer, 
            Autumn
        }


        public static string? getSeasonNameByMonth(int month, out string error)
        {
            var name = getSeasonName(getSeasonByMonth(month, out string errorSeason), out string errorName);
            error = errorSeason ?? errorName;

            return name;
        }

        public static string? getSeasonName(Seasons? season, out string error)
        {
            string name = "";
            if (season == Seasons.Winter)
            {
                name = "Зима";
            }
            else if (season == Seasons.Spring)
            {
                name = "Весна";
            }
            else if (season == Seasons.Summer)
            {
                name = "Лето";
            }
            else if (season == Seasons.Autumn)
            {
                name = "Осень";
            }
            else
            {
                error = "Неизвестный сезон";
                return null;
            }

            error = "";
            return name;
        }

        public static Seasons? getSeasonByMonth(int month, out string error)
        {
            if (month > 12 || month < 1)
            {
                error = "Ошибка: введите число от 1 до 12";
                return null;
            }
            
            Seasons season;
            error = "";

            if (month == 12 || month == 1 || month == 2)
            {
                season = Seasons.Winter;
            } 
            else if (month >= 3 && month <= 5)
            {
                season = Seasons.Spring;
            }
            else if (month >= 6 && month <= 8)
            {
                season = Seasons.Summer;
            }
            else 
            {
                season = Seasons.Autumn;
            }

            return season;
        }
    }
}