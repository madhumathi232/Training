using DigitalBook;
using DigitalBook.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

internal class UserValidationRequestModel
{
    private readonly DigitalBooksContext _context = new DigitalBooksContext();
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsValidate(string _userName,string _password)
    {
        if (_context.UserTables.Any(x => x.UserName == _userName && x.Password == EncryptionDecryption.EncodePasswordToBase64(_password)))
        return true;
    else
            return false;
    }

}