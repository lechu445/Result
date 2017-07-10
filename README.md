# Result
This is an idea of handling methods that can return error without using pattern TryMethod(out string error).

In this concept, we have 4 types of methods that does:
* not return anything and cannot fail (void methods)
* return some value and cannot fail (non-void methods)
* not return anything and can fail (returning Result)
* return some value and can fail (returning Result&lt;T>) 

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
  try
  {
    var person = new Person("John", "Doe");
    return Result.Ok(person);
  }
  catch(Exception ex)
  {
    return Result.Error(ex.Message);
  }
}
```
