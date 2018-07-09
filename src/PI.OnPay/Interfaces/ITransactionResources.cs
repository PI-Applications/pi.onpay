using System;
using System.Threading.Tasks;
using PI.OnPay.Models;

namespace PI.OnPay.Interfaces
{
    public interface ITransactionResources
    {
        Task<ResponseWithLinks<DetailedTransaction>> CancelTransaction(Guid transactionId);
        Task<ResponseWithLinks<DetailedTransaction>> CancelTransaction(int transactionId);
        Task<ResponseWithLinks<DetailedTransaction>> CancelTransaction(string resourceIdentifier);
        Task<ResponseWithLinks<DetailedTransaction>> CaptureTransaction(Guid transactionId, decimal? amount = null);
        Task<ResponseWithLinks<DetailedTransaction>> CaptureTransaction(int transactionId, decimal? amount = null);
        Task<ResponseWithLinks<DetailedTransaction>> CaptureTransaction(string resourceIdentifier, decimal? amount = null);
        Task<ResponseWithLinks<DetailedTransaction>> GetTransaction(Guid transactionId);
        Task<ResponseWithLinks<DetailedTransaction>> GetTransaction(int transactionId);
        Task<ResponseWithLinks<DetailedTransaction>> GetTransaction(string resourceIdentifier);
        Task<ResponseWithLinks<DetailedTransaction>> RefundTransaction(Guid transactionId, decimal? amount = null);
        Task<ResponseWithLinks<DetailedTransaction>> RefundTransaction(int transactionId, decimal? amount = null);
        Task<ResponseWithLinks<DetailedTransaction>> RefundTransaction(string resourceIdentifier, decimal? amount = null);
    }
}