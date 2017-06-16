class Character{
	private float _electricCharge;

	//constructor
	public Character()
	{
		_electricCharge = 100f;
	}
	public float GetEletricCharge()
	{
		return _electricCharge;
	}

	public void SetEletricCharge(float electricCharge)
	{
		_electricCharge = electricCharge;
	}
}