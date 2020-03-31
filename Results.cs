using System;

namespace MyApp
{
	[Serializable]
	public class Results
	{
		public ResultsType ResultType { get; set; }
		public string Message { get; set; }
		public bool IsSuccess => ResultType == ResultsType.Successful;

		public static Results Success() => Success(string.Empty);
		public static Results Success(string message) => Create(ResultsType.Successful, message);

		public static Results Error(string message) => Create(ResultsType.Error, message);

		public static Results Create(ResultsType type, string message)
		{
			return new Results { ResultType = type, Message = message };
		}
	}

	[Serializable]
	public class Results<T> : Results
	{
		public T Value { get; set; }

		public static Results<T> Success(T value) => Success(value, string.Empty);
		public static Results<T> Success(T value, string message) => new Results<T>
		{
			ResultType = ResultsType.Successful,
			Value = value,
			Message = message
		};

		new public static Results<T> Error(string message) => new Results<T>
		{
			ResultType = ResultsType.Error,
			Message = message
		};

		public static Results<T> Create(ResultsType type, string message, T value)
		{
			return new Results<T> { ResultType = type, Message = message, Value = value };
		}
	}

	public enum ResultsType
	{
		Unknown = -1,
		Error = 0,
		Successful = 1,
		Information = 2,
		Warning = 4,
		Other = 8,
		Updated = 16
	}
}
