namespace Result
{
  public struct Result<T>
  {
    public string ErrorMsg { get; }
    public T Value { get; }

    public bool IsError => !string.IsNullOrEmpty(ErrorMsg);
    public bool IsOk => !IsError;

    public Result(string error) { ErrorMsg = error; Value = default(T); }
    public Result(string error, T value) { ErrorMsg = error; Value = value; }
    public Result(T value) { ErrorMsg = null; Value = value; }

    public static Result<T> Error(string error) => new Result<T>(error);
    public static Result<T> Error(Result result) => new Result<T>(result.ErrorMsg);
    public static Result<T> Error<Y>(Result<Y> result) => new Result<T>(result.ErrorMsg);

    public static Result<T> Ok(T value) => new Result<T>(value);

    public Result<T> Combine(Result result) => Combine(this, result);
    public Result<T> Combine(Result<T> result) => Combine(this, result);

    public static Result<T> Combine(Result<T> that, Result result)
    {
      string err = that.IsError ? that.ErrorMsg : result.ErrorMsg;
      return new Result<T>(err, that.Value);
    }

    public static Result<T> Combine(Result<T> that, Result<T> result)
    {
      string err = that.IsError ? that.ErrorMsg : result.ErrorMsg;
      T val = default(T).Equals(that.Value) ? result.Value : that.Value;
      return new Result<T>(err, val);
    }

    public static implicit operator Result(Result<T> result) => new Result(result.ErrorMsg);
    public static implicit operator Result<T>(Result result) => new Result(result.ErrorMsg);
  }

  public struct Result
  {
    public string ErrorMsg { get; }
    private static Result OkResultInstance = new Result();

    public bool IsError => !string.IsNullOrEmpty(ErrorMsg);
    public bool IsOk => !IsError;
    
    public Result(string error) { this.ErrorMsg = error; }

    public static Result Error(string error) => new Result(error);
    public static Result Ok() => OkResultInstance;
    public static Result<T> Error<T>(Result result) => new Result<T>(result.ErrorMsg);
    public static Result<T> Error<T>(string error) => new Result<T>(error);
    public static Result<T> Ok<T>(T value) => new Result<T>(value);
    
    public Result<T> Combine<T>(Result<T> result) => Combine(this, result);
    public Result Combine<T>(Result result) => Combine<T>(this, result);

    public static Result<T> Combine<T>(Result that, Result<T> result)
    {
      string err = that.IsError ? that.ErrorMsg : result.ErrorMsg;
      return new Result<T>(err, result.Value);
    }

    public static Result Combine<T>(Result that, Result result)
    {
      string err = that.IsError ? that.ErrorMsg : result.ErrorMsg;
      return new Result(err);
    }

  }
}
