namespace Template.Models
{
	public class DataResult<T> : Result
	{
		public T Data { get; protected set; }

		public static DataResult<T> Successful(T data)
		{
			return new DataResult<T>()
			{
				Success = true,
				Data = data
			};
		}
	}
}