# Result
## Usage
```csharp
pubilic static void Main(string[] args)
{
  Result firstMethodResult = VoidMethodThatCanReturnError();
  if(firstMethodResult.IsOk)
  {
    Console.WriteLine("first method finished without an error");
  }
  else
  {
    Console.WriteLine(firstMethodResult.ErrorMsg);
  }
  
  Result<Person> secondMethodResult = ReturningMethodThatCanReturnError();
  if(secondMethodResult.IsError)
  {
    Console.WriteLine(secondMethodResult.ErrorMsg);
  }
  else
  {
    Console.WriteLine(secondMethodResult.Value.Name);
  }
}

private Result VoidMethodThatCanReturnError()
{
  if(condition)
  {
    return Result.Error("error message")
  }
  else
  {
    return Result.Ok();
  }
}

private Result<Person> ReturningMethodThatCanReturnError()
{
  if(condition)
  {
    return Result.Error("error message")
  }
  else
  {
    var person = new Person("John", "Doe");
    return Result.Ok(person);
  }
}
```
