namespace AutomationPractice.Pages.SignIn
{
    internal class SignInForm
    {
        private string _title;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _addressLine1;
        private string _city;
        private string _postalCode;
        private string _mobilePhone;
        private string _addressAlias;
        private string _state;
        private string _country = "United States";

        public string Title { get => _title; set => _title = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string AddressLine1 { get => _addressLine1; set => _addressLine1 = value; }
        public string City { get => _city; set => _city = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string MobilePhone { get => _mobilePhone; set => _mobilePhone = value; }
        public string AddressAlias { get => _addressAlias; set => _addressAlias = value; }
        public string State { get => _state; set => _state = value; }
        public string Country { get => _country; set => _country = value; }

        public static SignInForm GetValidForm()
        {
            var form = new SignInForm();
            form.Title = "Mr.";
            form.FirstName = "Ondra";
            form.LastName = "Nanas";
            form.Password = "Password";
            form.AddressLine1 = "Line 1";
            form.City= "City";
            form.PostalCode = "12345";
            form.MobilePhone = "123-456-789";
            form.AddressAlias = "Address alias";
            form.State = "Alabama";
            return form;
        }
    }
}
