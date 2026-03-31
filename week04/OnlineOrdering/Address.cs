public class Address
{
   private string _street;
   private string _city;
   private string _stateProvince;
   private string _country;



   public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public string GetStreet()
    {
        return _street;
    }
    public void SetStreet(string value)
     {
     _street = value; 
     }

    public string GetCity() {return _city;}
    public void SetCity(string value) 
    {
    _city = value;
    }

    public string GetStateProvince()
    {
        return _stateProvince;
    }

    public void GetStateProvince(string value)
    {
        _stateProvince = value;
    }


    public string GetCountry()
    {
        return _country;
    }

    public void SetCountry(string value)
    {
        _country = value;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

}