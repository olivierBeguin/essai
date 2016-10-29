using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDAL
{
    public class BankAccountManager
    {

        public void TransfererArgent(string ibanOrigine, string ibanDestination, int montantATransferer)
        {
            using (SqlConnection cn = GetDatabaseConnection())
            {
                cn.Open();
                //Encapsuler les deux en transactions
                using (SqlTransaction transaction = cn.BeginTransaction())
                {

                    try
                    {
                        DebiterDe(montantATransferer, ibanOrigine, cn, transaction);
                        CrediterDe(montantATransferer, ibanDestination, cn, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
                
            }
        }

        private void CrediterDe(int montantAAjouter, string iban, SqlConnection cn, SqlTransaction transaction)
        {
            var command = new SqlCommand("UPDATE [CompteEnBanque] SET [Solde]=[Solde]+@montantAAjouter WHERE [IBAN]=@iban", cn);
            command.Parameters.AddWithValue("@montantAAjouter", montantAAjouter);
            command.Parameters.AddWithValue("@iban", iban);
            command.Transaction = transaction;
            ExecuterRequeteEtVerifierImpact(command);
        }

        private void DebiterDe(int montantARetirer, string iban, SqlConnection cn, SqlTransaction transaction)
        {
            var command = new SqlCommand("UPDATE [CompteEnBanque] SET [Solde]=[Solde]-@montantARetirer WHERE [IBAN]=@iban", cn);
            command.Parameters.AddWithValue("@montantARetirer", montantARetirer);
            command.Parameters.AddWithValue("@iban", iban);
            command.Transaction = transaction;
            ExecuterRequeteEtVerifierImpact(command);
        }

        private static void ExecuterRequeteEtVerifierImpact(SqlCommand command)
        {
            var nombreDeComptesEnBanqueAffectes = command.ExecuteNonQuery();
            if (nombreDeComptesEnBanqueAffectes != 1)
                throw new BankAccountNotFoundException();
        }

        public static SqlConnection GetDatabaseConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MyVeryPrimitiveBank"].ConnectionString);
        }

        public double ObtenirSolde(string iban)
        {
            using (SqlConnection connection = GetDatabaseConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT [Solde] FROM [CompteEnBanque] WHERE [IBAN]=@iban", connection);
                command.Parameters.AddWithValue("@iban", iban);
                var solde = (decimal)command.ExecuteScalar();
                connection.Close();
                return Convert.ToDouble(solde);
            }
        }
    }
}
