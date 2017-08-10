namespace InstaCore.Models.DataTransferObjects
{
  public class AccountDetailDto
  {
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public AccountType Type { get; set; }
    public string Description { get; set; }
    public double Balance { get; set; }
  }
}
