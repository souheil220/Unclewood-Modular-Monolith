using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Unclewood.Modules.Ingredients.Domain;

public sealed class Price
{
    private const decimal MinValue = 100m;
    private const decimal MaxValue = 10000m;
    
    public decimal Value { get; }
    public string Currency { get; init; } = string.Empty; 
    
    private Price() // Default values for EF Core
    {
    }

    [JsonConstructor]
    private Price(decimal value, string currency)
    {
        Value = decimal.Round(value, 2);
        Currency = currency;
    }
    
    
    public static Price Create(decimal value, string currency)
    {
        ValidatePrice(value);
        ValidateCurrency(currency);
        return new Price(value, currency);
    }
    
    private static void ValidatePrice(decimal value)
    {
        if (value < MinValue)
        {
           throw new PriceDomainException($"Price cannot be less than {MinValue}");
        }

        if (value > MaxValue)
        {
            throw new PriceDomainException($"Price cannot exceed {MaxValue}");
        }

        if (decimal.Round(value, 2) != value)
        {
            throw new PriceDomainException("Price cannot have more than 2 decimal places");
        }
    }
    
    private static Result<string> ValidateCurrency(string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
        {
            return Result.Failure<string>(
                new Error(
                    "PriceDomainException.ValidateCurrency",
                    "Currency cannot be empty"));

        }

        var normalizedCurrency = currency.Trim().ToUpper();
        var validCurrencies = new[] { "DZD", "USD", "EUR" };
        
        if (!validCurrencies.Contains(normalizedCurrency))
        {
            return Result.Failure<string>(
                new Error(
                    "PriceDomainException.ValidateCurrency",
                    "Currency {currency} is not supported"));
            
        }

        return Result.Success(normalizedCurrency).Value;
    }

    private Result<Price> MultiplyBy(decimal multiplier)
    {
        if (multiplier < 0)
        {
            return Result.Failure<Price>(
                new Error(
                    "PriceDomainException.MultiplyBy",
                    "Multiplier cannot be negative"));

        }

        var result = Create(Value * multiplier, Currency);
        
        return Result.Success(result);
    }
    
    public Result<Price> ApplyDiscount(decimal percentageDiscount)
    {
        var discountMultiplier = 1 - (percentageDiscount / 100);
        
        var result = MultiplyBy(discountMultiplier);
        if (result.IsFailure)
        {
            return Result.Failure<Price>(result.Error);
        }

        return result.Value;
    }
    
    private void EnsureSameCurrency(Price other)
    {
        if (Currency != other.Currency)
        {
            throw new PriceDomainException($"Cannot compare prices with different currencies: {Currency} and {other.Currency}");   
        }
        
    }

    public bool IsGreaterThan(Price other)
    {
        EnsureSameCurrency(other);
        return Value > other.Value;
    }

    public bool IsLessThan(Price other)
    {
        EnsureSameCurrency(other);
        return Value < other.Value;
    }
    
    
    public IEnumerable<object?> GetEqualityComponent()
    {
        yield return Value;
        yield return Currency;
    }   
}