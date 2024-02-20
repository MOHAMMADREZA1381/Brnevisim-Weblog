using Domain.Models;
using Persia_.NET_Core;

namespace Application.Convertor;

public class ConvertDateToShamsi
{
    public static string ConvertDateToSh(DateTime date)
    {
        SolarDate solar = Calendar.ConvertToPersian(date);
        string str = solar.ToString("W");
        return str;
    }

}