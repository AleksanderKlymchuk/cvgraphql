namespace Model
{
	public struct Property<T>
	{
		private T value;
		public bool IsSet { get; private set; }


		public T Value
		{
			get { return value; }
			set
			{
				this.value = value;
				IsSet = true;
			}
		}


		public static implicit operator T(Property<T> value)
		{
			return value.Value;
		}
		public static implicit operator Property<T>(T value)
		{
			return new Property<T>
			{
				Value = value
			};
		}


	}
}

