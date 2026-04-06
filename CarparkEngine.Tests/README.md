# Carpark Engine Tests

xUnit test project for the [Carpark Engine](../CarparkEngine) application.

## Test Coverage

| Test Class | Scope |
|------------|-------|
| `PriceCalculatorTest` | Validates price calculation for Standard, Weekend, and other rate scenarios |
| `QueryTest` | Verifies the instruction string and pricing rate list returned by the Query API |
| `MutationTest` | Tests ticket submission with valid input, default/null values, reversed entry/exit, future dates, and `DateTime.MinValue` |
| `ModelTest` | Covers model instantiation and property assignment |

## Running Tests

From the Carpark Engine solution in Visual Studio, or from the command line:

```
dotnet test
```
