namespace UnityTest
{
    public class MyOtherHelper : IOtherHelper
    {
        private ISqlHelper sql;

        public MyOtherHelper(ISqlHelper sql)
        {
            this.sql = sql;
        }

        public string GetSqlConnection()
        {
            return this.sql.SqlConnection();
        }
    }
}