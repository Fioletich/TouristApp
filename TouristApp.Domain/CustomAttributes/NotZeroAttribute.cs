using System.ComponentModel.DataAnnotations;

namespace TouristApp.Domain.CustomAttributes;

public class NotZeroAttribute : ValidationAttribute{
    public override bool IsValid(object value) {
        return (decimal) value != 0;
    }
}