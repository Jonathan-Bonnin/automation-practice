namespace AutomationPractice.Pages.ContactUs
{
    internal class ContactUsForm
    {
        private string _email;
        private string _message;
        private string _filePath;
        private string _orderNumber;
        private InternalTeam _internalTeam;
        private ContactUsForm() { }
        public string Email { get => _email; set => _email = value; }
        public string Message { get => _message; set => _message = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
        public string OrderNumber { get => _orderNumber; set => _orderNumber = value; }
        internal InternalTeam InternalTeam { get => _internalTeam; set => _internalTeam = value; }

        public static ContactUsForm getValidForm()
        {
            ContactUsForm form = new ContactUsForm();

            form.Email = "valid@email.com";
            form.Message = "valid message";
            form.InternalTeam = InternalTeam.CustomerService;

            return form;
        }
    }
}
