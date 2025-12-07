using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStation.Domain.Exceptions
{
    public class ArgumentNullValueException(string paramName)
        : ArgumentNullException(paramName, $"Argument \"{paramName}\" value is null"); // ArgumentNullException, Исключение, которое создается при передаче пустой ссылки (Nothing в Visual Basic) методу, который не принимает ее как допустимый аргумент.
                                                                                       // Наследование. Object ==> Exception ==> SystemException ==> ArgumentException ==> ArgumentNullException
}
