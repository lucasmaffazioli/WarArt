using WarArt.Models;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace WarArt
{
    public class DalHelper
    {
        private static SQLiteConnection sqliteConnection;
        public DalHelper()
        { }
        private static SQLiteConnection DbConnection()
        {

            if (!System.IO.File.Exists(@"db.sqlite3"))
            {
                Console.WriteLine("Just entered to create DB");
                SQLiteConnection.CreateFile(@"db.sqlite3");

                CriarTabelaSQlite();
                return sqliteConnection;
            }
            else
            {
                sqliteConnection = new SQLiteConnection("Data Source=db.sqlite3; Version=3;");
                sqliteConnection.Open();
                return sqliteConnection;
            }
           
        }
        
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Historico(state TEXT, seconds INTEGER, start TEXT, end TEXT)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllHistoricos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Historico";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteAllHistoricos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Historico";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDailySummary()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT state, strftime('%d-%m-%Y', start) date, time(SUM(seconds), 'unixepoch') totalTime FROM Historico group by state, date ORDER BY date DESC, state";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetHistorico(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Historico Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Add(Historico historico)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Historico(state, seconds, start, end) values (@state, @seconds, @start, @end)";
                    cmd.Parameters.AddWithValue("@state", historico.state);
                    cmd.Parameters.AddWithValue("@seconds", historico.seconds);
                    cmd.Parameters.AddWithValue("@start", historico.start);
                    cmd.Parameters.AddWithValue("@end", historico.end);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public static void Update(Historico historico)
        //{
        //    try
        //    {
        //        using (var cmd = new SQLiteCommand(DbConnection()))
        //        {
        //            if (cliente.Id != null)
        //            {
        //                cmd.CommandText = "UPDATE Clientes SET Nome=@Nome, Email=@Email WHERE Id=@Id";
        //                cmd.Parameters.AddWithValue("@Id", cliente.Id);
        //                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
        //                cmd.Parameters.AddWithValue("@Email", cliente.Email);
        //                cmd.ExecuteNonQuery();
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void Delete(int Id)
        //{
        //    try
        //    {
        //        using (var cmd = new SQLiteCommand(DbConnection()))
        //        {
        //            cmd.CommandText = "DELETE FROM Clientes Where Id=@Id";
        //            cmd.Parameters.AddWithValue("@Id", Id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private static String ConvertDateTimeToString(DateTime dateTime)
        {
            try
            {
                return dateTime.ToString("yyyy-MM-dd hh:mm:ss"); ;
            }
            catch
            {
                throw new Exception("Unable to parse.");
            }
        }
        private static DateTime ConvertToDateTime(string str)
        {
            string pattern = @"(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})\.(\d{3})";
            if (Regex.IsMatch(str, pattern))
            {
                Match match = Regex.Match(str, pattern);
                int year = Convert.ToInt32(match.Groups[1].Value);
                int month = Convert.ToInt32(match.Groups[2].Value);
                int day = Convert.ToInt32(match.Groups[3].Value);
                int hour = Convert.ToInt32(match.Groups[4].Value);
                int minute = Convert.ToInt32(match.Groups[5].Value);
                int second = Convert.ToInt32(match.Groups[6].Value);
                int millisecond = Convert.ToInt32(match.Groups[7].Value);
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            else
            {
                throw new Exception("Unable to parse.");
            }
        }
    }
}