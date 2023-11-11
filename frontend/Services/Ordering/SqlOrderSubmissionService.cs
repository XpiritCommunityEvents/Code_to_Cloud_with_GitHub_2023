using System.Data.SqlClient;
using GloboTicket.Frontend.Models.View;
using GloboTicket.Frontend.Services.Ordering;

public class SqlOrderSubmissionService : IOrderSubmissionService
{
    private readonly SqlConnection _sqlConnection;

    public SqlOrderSubmissionService(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public async Task<Guid> SubmitOrder(CheckoutViewModel checkoutViewModel)
    {
        await _sqlConnection.OpenAsync();
        var id = Guid.NewGuid();
        string query = $"INSERT INTO Orders (BasketId, BuyerName, ShipToAddress_Street) VALUES ({checkoutViewModel.BasketId}, {checkoutViewModel.Name}, {checkoutViewModel.Address})";
        using var command = new SqlCommand(query, _sqlConnection);
        await command.ExecuteNonQueryAsync();
        return id;
    }
}
