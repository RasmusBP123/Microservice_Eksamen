using System;
using System.Data.SqlClient;

namespace Persistence
{
    public interface IConnectionFactory
    {
        SqlConnection SqlConnection();
    }
}
