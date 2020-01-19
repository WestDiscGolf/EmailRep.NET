using System.Threading;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET
{
    /// <summary>
    /// Email Rep IO client interface
    /// </summary>
    public interface IEmailRepClient
    {
        /// <summary>
        /// Query the emailrep.io email database.
        /// </summary>
        /// <param name="emailAddress">Valid email address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<QueryResponse> QueryEmailAsync(string emailAddress, CancellationToken cancellationToken = default);
    }
}